using System;
using System.Collections.Generic;

namespace MiniDSL {
	
	/// <summary>
	/// Schedule context.
	/// </summary>
	public interface IScheduleContext {

		/// <summary>
		/// Write line.
		/// </summary>
		Action<string> WriteLine {
			get;
			set;
		}

		/// <summary>
		/// Schedule.
		/// </summary>
		IEnumerable<ScheduleItem> Schedule {
			get;
			set;
		}

		/// <summary>
		/// Start date.
		/// </summary>
		DateTime? StartDate {
			get;
			set;
		}

		/// <summary>
		/// End date.
		/// </summary>
		DateTime? EndDate {
			get;
			set;
		}

		/// <summary>
		/// Equal date.
		/// </summary>
		DateTime? EqualDate {
			get;
			set;
		}
		
		/// <summary>
		/// Equal bus.
		/// </summary>
		int? EqualBus {
			get;
			set;
		}

		/// <summary>
		/// Get result.
		/// </summary>
		/// <returns><see cref="ScheduleItem"/> sequence for current state.</returns>
		IEnumerable<ScheduleItem> GetResult ();

	}

}
