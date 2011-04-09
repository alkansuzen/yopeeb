using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Beeps.
	/// </summary>
	public class Beep
	{
		public Int64 BeepId { get; set; }
		public string Text { get; set; }
		public Int64 UserId { get; set; }
		public Int64 EventId { get; set; }
		public Int64 PlaceId { get; set; }
		public Int64 TimeId { get; set; }
		public Int64 BeepIdFather { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

