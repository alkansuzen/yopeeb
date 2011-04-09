using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for BeepsTags.
	/// </summary>
	public class BeepTag
	{
		public Int64 BeepId { get; set; }
		public Int64 TagId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

