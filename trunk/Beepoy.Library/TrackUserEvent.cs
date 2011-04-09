using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for TrackUsersEvents.
	/// </summary>
	public class TrackUserEvent
	{
		public Int64 UserId { get; set; }
		public Int64 EventId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

