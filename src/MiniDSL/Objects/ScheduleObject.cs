using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDSL.DSL.Objects;

namespace MiniDSL.Objects {

	public class ScheduleObject : MiniDSLObject {

		public ScheduleObject ( ConditionObjectFactory factory )
			: base ( MiniDSLObjectType.Property , factory ) {
			InnerObjects.Add ( "дляавтобуса" , Factory.CreateEqualBusObject () );
			InnerObjects.Add ( "наавтобус" , Factory.CreateEqualBusObject () );
			InnerObjects.Add ( "за" , Factory.CreateEqualDateObject () );
			InnerObjects.Add ( "с" , Factory.CreateStartDateObject () );
			InnerObjects.Add ( "по" , Factory.CreateEndDateObject () );
		}

		public override void OnGetProperty () {
			var context = ( Context as IScheduleContext );

			var result = new List<ScheduleItem> ();

			var firstBusNumber = 11;
			var firstBusDate = DateTime.Now.Date.AddHours ( 7 );
			for ( var i = 0 ; i < 14 ; i++ ) {
				firstBusDate = firstBusDate.AddHours ( 1 );
				result.Add (
					new ScheduleItem {
						BusNumber = firstBusNumber ,
						Date = firstBusDate
					}
				);
			}

			var secondBusNumber = 15;
			var secondBusDate = DateTime.Now.Date.AddHours ( 3 );
			for ( var i = 0 ; i < 30 ; i++ ) {
				secondBusDate = secondBusDate.AddMinutes ( 30 );
				result.Add (
					new ScheduleItem {
						BusNumber = secondBusNumber ,
						Date = secondBusDate
					}
				);
			}

			context.Schedule = result;
		}

	}

}
