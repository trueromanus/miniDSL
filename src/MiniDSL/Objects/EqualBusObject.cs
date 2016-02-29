using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	public class EqualBusObject : MiniDSLObject {

		public EqualBusObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Method , factory ) {
		}

		public override object GetParameter () {
			var parameter = Input.Dequeue ();
			int busNumber;
			if ( !int.TryParse ( parameter , out busNumber ) ) throw new FormatException ( "Bus number specify with incorrect format." );

			return busNumber;
		}

		public override bool TryInvoke ( InvokeBinder binder , object[] args , out object result ) {
			var context = Context as IScheduleContext;
			if ( context == null ) throw new InvalidOperationException ( "Context incorrect type." );

			context.EqualBus = (int) args[0];

			result = this;
			return true;
		}

	}

}
