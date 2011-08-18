using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for EventsTags.
	/// </summary>
	public class EventTag
	{
		public Int64 TagId { get; set; }
		public Int64 EventId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

