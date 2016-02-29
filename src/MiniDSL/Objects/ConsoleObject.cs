using System;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	/// <summary>
	/// Console object.
	/// </summary>
	public class ConsoleObject : MiniDSLObject {

		public ConsoleObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Property , factory ) {
			InnerObjects.Add ( "расписание" , new ScheduleObject (factory) );
		}

		public override void OnGetProperty () {
			var context = ( Context as IScheduleContext );
			if ( context == null ) throw new InvalidOperationException ( "Context incorrect type." );

			context.WriteLine = ( message ) => {
				Console.WriteLine ( message );
			};
		}

	}
}
