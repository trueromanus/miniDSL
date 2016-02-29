using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniDSL.DSL.Objects;
using MiniDSL.Objects;

namespace MiniDSL {
	
	class Program {

		static void Main ( string[] args ) {
			BusAndDateRange ();

			//uncomment different filters for this scenario
			//BusAndConcreteDate();
			//DateRangeOnly ();
			//BusOnly ();
			//BusAndConcreteDateDynamic ();

			Console.ReadKey ();
		}

		private static void BusAndDateRange () {
			var input = "Показать на консоли расписание на автобус 15 с " + DateTime.Now.Date.AddHours ( 12 ) + " по " + DateTime.Now.Date.AddHours ( 18 );
			var context = new ScheduleContext ();
			var rootObject = new RootObject ( new ConditionObjectFactory () );
			rootObject.Context = context;
			rootObject.Input = new Queue<string> ( input.Split ( ' ' ) );

			MiniDSLObject currentObject = rootObject;
			while ( rootObject.Input.Count > 0 ) {
				currentObject = currentObject.GetObject ();
			}

			var items = context.GetResult ();
			foreach ( var item in items ) {
				context.WriteLine ( string.Format ( "Автобус {0} время {1:dd:MM:yyyy hh:mm:ss}" , item.BusNumber , item.Date ) );
			}
		}

		private static void DateRangeOnly () {
			var input = "Показать на консоли расписание с " + DateTime.Now.Date.AddHours ( 12 ) + " по " + DateTime.Now.Date.AddHours ( 18 );
			var context = new ScheduleContext ();
			var rootObject = new RootObject ( new ConditionObjectFactory () );
			rootObject.Context = context;
			rootObject.Input = new Queue<string> ( input.Split ( ' ' ) );

			MiniDSLObject currentObject = rootObject;
			while ( rootObject.Input.Count > 0 ) {
				currentObject = currentObject.GetObject ();
			}

			var items = context.GetResult ();
			foreach ( var item in items ) {
				context.WriteLine ( string.Format ( "Автобус {0} время {1:dd:MM:yyyy hh:mm:ss}" , item.BusNumber , item.Date ) );
			}
		}

		private static void BusOnly () {
			var input = "Показать на консоли расписание на автобус 11";
			var context = new ScheduleContext ();
			var rootObject = new RootObject ( new ConditionObjectFactory () );
			rootObject.Context = context;
			rootObject.Input = new Queue<string> ( input.Split ( ' ' ) );

			MiniDSLObject currentObject = rootObject;
			while ( rootObject.Input.Count > 0 ) {
				currentObject = currentObject.GetObject ();
			}

			var items = context.GetResult ();
			foreach ( var item in items ) {
				context.WriteLine ( string.Format ( "Автобус {0} время {1:dd:MM:yyyy hh:mm:ss}" , item.BusNumber , item.Date ) );
			}
		}

		private static void BusAndConcreteDate () {
			var input = "Показать на консоли расписание на автобус 15 за " + DateTime.Now.Date.ToString("dd.MM.yyyy hh:mm:ss");
			var context = new ScheduleContext ();
			var rootObject = new RootObject ( new ConditionObjectFactory () );
			rootObject.Context = context;
			rootObject.Input = new Queue<string> ( input.Split ( ' ' ) );

			MiniDSLObject currentObject = rootObject;
			while ( rootObject.Input.Count > 0 ) {
				currentObject = currentObject.GetObject ();
			}

			var items = context.GetResult ();
			foreach ( var item in items ) {
				context.WriteLine ( string.Format ( "Автобус {0} время {1:dd:MM:yyyy hh:mm:ss}" , item.BusNumber , item.Date ) );
			}
		}

		private static void BusAndConcreteDateDynamic () {
			var context = new ScheduleContext ();
			var rootObject = new RootObject ( new ConditionObjectFactory () );
			rootObject.Context = context;

			dynamic currentObject = rootObject;
			currentObject.Показать.НаКонсоли.Расписание.НаАвтобус ( 15 ).За ( DateTime.Now.Date );

			var items = context.GetResult ();
			foreach ( var item in items ) {
				context.WriteLine ( string.Format ( "Автобус {0} время {1:dd:MM:yyyy hh:mm:ss}" , item.BusNumber , item.Date ) );
			}
		}

	}

}
