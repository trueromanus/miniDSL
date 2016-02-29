using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	public class ConditionObjectFactory {

		private IDictionary<Type , MiniDSLObject> m_ObjectPool = new Dictionary<Type , MiniDSLObject> ();

		public ConditionObjectFactory () {
			var equalDate = new EqualDateObject ( this );
			var equalBus = new EqualBusObject ( this );
			var startDate = new StartDateObject ( this );
			var endDate = new EndDateObject ( this );

			m_ObjectPool.Add ( typeof ( EqualDateObject ) , equalDate );
			m_ObjectPool.Add ( typeof ( EqualBusObject ) , equalBus );
			m_ObjectPool.Add ( typeof ( StartDateObject ) , startDate );
			m_ObjectPool.Add ( typeof ( EndDateObject ) , endDate );

			EqualDateFillInnerObject ( equalDate );
			EqualBusFillInnerObject ( equalBus );
			StartDateFillInnerObject ( startDate );
			EndDateFillInnerObject ( endDate );
		}

		public EqualBusObject CreateEqualBusObject () {

			var instance = new EqualBusObject ( this );
			EqualBusFillInnerObject ( instance );

			return instance;
		}

		private void EqualBusFillInnerObject ( EqualBusObject instance ) {
			instance.InnerObjects.Add ( "за" , (EqualDateObject) m_ObjectPool[typeof ( EqualDateObject )] );
			instance.InnerObjects.Add ( "с" , (StartDateObject) m_ObjectPool[typeof ( StartDateObject )] );
			instance.InnerObjects.Add ( "по" , (EndDateObject) m_ObjectPool[typeof ( EndDateObject )] );
		}

		public EqualDateObject CreateEqualDateObject () {
			var instance = new EqualDateObject ( this );
			EqualDateFillInnerObject ( instance );

			return instance;
		}

		private void EqualDateFillInnerObject ( EqualDateObject instance ) {
			instance.InnerObjects.Add ( "с" , (StartDateObject) m_ObjectPool[typeof ( StartDateObject )] );
			instance.InnerObjects.Add ( "по" , (EndDateObject) m_ObjectPool[typeof ( EndDateObject )] );
		}

		public StartDateObject CreateStartDateObject () {
			var instance = new StartDateObject ( this );

			StartDateFillInnerObject ( instance );

			return instance;
		}

		private void StartDateFillInnerObject ( StartDateObject instance ) {
			instance.InnerObjects.Add ( "за" , (EqualDateObject) m_ObjectPool[typeof ( EqualDateObject )] );
			instance.InnerObjects.Add ( "по" , (EndDateObject) m_ObjectPool[typeof ( EndDateObject )] );
		}

		public EndDateObject CreateEndDateObject () {
			var instance = new EndDateObject ( this );

			EndDateFillInnerObject ( instance );

			return instance;
		}

		private void EndDateFillInnerObject ( EndDateObject instance ) {
			instance.InnerObjects.Add ( "за" , (EqualDateObject) m_ObjectPool[typeof ( EqualDateObject )] );
			instance.InnerObjects.Add ( "с" , (StartDateObject) m_ObjectPool[typeof ( StartDateObject )] );
		}

	}

}
