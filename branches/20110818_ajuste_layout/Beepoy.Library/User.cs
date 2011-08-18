using System;
using System.Collections.Generic;

namespace Beepoy.Library
{
	/// <summary>
	/// Summary description for UsersModel.
	/// </summary>
	public class User
	{
		public Int64 UserId { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public DateTime DateInsert { get; set; }
		public DateTime DateUpdate { get; set; }
        public List<Beep> Beeps { get; set; }
	}
}

