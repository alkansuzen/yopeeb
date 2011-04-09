using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Tags.
	/// </summary>
	public class Tag
	{
		public Int64 TagId { get; set; }
		public string Text { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

