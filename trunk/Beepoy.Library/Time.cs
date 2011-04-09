using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Times.
	/// </summary>
	public class Time
	{
		public Int64 TimeId { get; set; }
		public DateTime Value { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

