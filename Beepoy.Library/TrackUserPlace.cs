using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for TrackUsersPlaces.
	/// </summary>
	public class TrackUserPlace
	{
		public Int64 UserId { get; set; }
		public Int64 PlaceId { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
	}
}

