using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	/// <summary>
	/// Root object.
	/// </summary>
	public class RootObject : MiniDSLObject {

		public RootObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Property , factory ) {
				InnerObjects.Add ( "показать" , new ShowObject ( factory ) );
		}

	}

}
