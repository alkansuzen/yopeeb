using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for Places.
	/// </summary>
	public class Place
	{
		public Int64 PlaceId { get; set; }
		public string Name { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public Int64 UserId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

