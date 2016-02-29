using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniDSL.Objects {
	
	public class ScheduleContext : IScheduleContext {

		public ScheduleContext () {
		}

		public Action<string> WriteLine {
			get;
			set;
		}

		public IEnumerable<ScheduleItem> Schedule {
			get;
			set;
		}

		public DateTime? StartDate {
			get;
			set;
		}

		public DateTime? EndDate {
			get;
			set;
		}

		public DateTime? EqualDate {
			get;
			set;
		}

		public int? EqualBus {
			get;
			set;
		}

		public IEnumerable<ScheduleItem> GetResult () {
			return Schedule
				.Where (
				a =>
					( StartDate == null || !StartDate.HasValue || a.Date >= StartDate.Value ) &&
					( EndDate == null || !EndDate.HasValue || a.Date <= EndDate.Value ) &&
					( EqualDate == null || !EqualDate.HasValue || a.Date.Date == EqualDate.Value.Date ) &&
					( EqualBus == null || !EqualBus.HasValue || a.BusNumber == EqualBus.Value )
				)
				.ToList ();
		}
	}

}
