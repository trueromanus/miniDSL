using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using MiniDSL.Objects;

namespace MiniDSL.DSL.Objects {

	/// <summary>
	/// Mini DSL object.
	/// </summary>
	public class MiniDSLObject : DynamicObject {

		private readonly IDictionary<string , MiniDSLObject> m_innerObjects = new Dictionary<string , MiniDSLObject> ();

		private readonly MiniDSLObjectType m_Type;
		
		private readonly ConditionObjectFactory m_Factory;

		public MiniDSLObject ( MiniDSLObjectType type , ConditionObjectFactory factory ) {
			m_Type = type;
			m_Factory = factory;
		}

		/// <summary>
		/// Inner objects for derived classes.
		/// </summary>
		public IDictionary<string , MiniDSLObject> InnerObjects {
			get {
				return m_innerObjects;
			}
		}

		/// <summary>
		/// Common context.
		/// </summary>
		public object Context {
			get;
			set;
		}

		/// <summary>
		/// Input strings.
		/// </summary>
		public Queue<string> Input {
			get;
			set;
		}

		/// <summary>
		/// Object type.
		/// </summary>
		public MiniDSLObjectType Type {
			get {
				return m_Type;
			}
		}

		/// <summary>
		/// Factory.
		/// </summary>
		public ConditionObjectFactory Factory {
			get {
				return m_Factory;
			}
			
		}

		public MiniDSLObject GetObject () {
			var objectName = GetNextWord ();
			while ( Input.Any () ) {
				if ( m_innerObjects.ContainsKey ( objectName ) ) {
					var @object = GetAndPrepareInnerObject ( objectName );
					switch ( @object.Type ) {
						case MiniDSLObjectType.Property:
							@object.OnGetProperty ();
							return @object;
						case MiniDSLObjectType.Method:
							dynamic dynamicObject = @object;
							return dynamicObject ( @object.GetParameter () );
						default: throw new NotSupportedException ( string.Format ( "Object type {0} not supported." , @object.Type ) );
					}
				}
				objectName += GetNextWord ();
			}
			throw new FormatException ( "Unknown command." );
		}

		private string GetNextWord () {
			return Input.Dequeue ().ToLower ();
		}

		private MiniDSLObject GetAndPrepareInnerObject ( string name ) {
			var @object = m_innerObjects[name];
			@object.Input = Input;
			@object.Context = Context;
			return @object;
		}

		public virtual object GetParameter () {
			return null;
		}

		public virtual void OnGetProperty () {
		}

		public override bool TryGetMember ( GetMemberBinder binder , out object result ) {
			var name = binder.Name.ToLower ();
			if ( !m_innerObjects.ContainsKey ( name ) ) throw new InvalidOperationException ( string.Format ( "Inner object with name {0} not found." , binder.Name ) );

			var @object = GetAndPrepareInnerObject ( name );
			@object.OnGetProperty ();
			result = @object;
			return true;
		}


	}

}
