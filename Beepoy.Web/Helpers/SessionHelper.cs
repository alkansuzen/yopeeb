using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Beepoy.Web.Models;

namespace Beepoy.Web.Helpers
{
    public class SessionHelper
    {
        public static User User {
            get {
                User user = (User)HttpContext.Current.Session["user"];
                return user; // TODO: try/catch
            }
        }
    }
}