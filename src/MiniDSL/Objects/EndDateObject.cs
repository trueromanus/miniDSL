using System;
using System.Dynamic;
using System.Text.RegularExpressions;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	public class EndDateObject : MiniDSLObject {

		public EndDateObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Method , factory ) {
		}

		public override object GetParameter () {
			var dateParameter = Input.Dequeue ();
			if ( Regex.IsMatch ( Input.Peek () , @"\d\d:\d\d:\d\d" ) ) {
				dateParameter += " " + Input.Dequeue ();
			}
			DateTime date;
			if ( !DateTime.TryParse ( dateParameter , out date ) ) throw new FormatException ( "Date specify with incorrect format." );

			return date;
		}

		public override bool TryInvoke ( InvokeBinder binder , object[] args , out object result ) {
			var context = Context as IScheduleContext;
			if ( context == null ) throw new InvalidOperationException ( "Context incorrect type." );

			context.EndDate = (DateTime) args[0];

			result = this;
			return true;
		}

	}

}
