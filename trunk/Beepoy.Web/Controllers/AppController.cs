using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;


namespace Beepoy.Web.Controllers
{
    public class AppController : Controller
    {
        
        //DataBase connection
        private MvcBeepoyEntities db = new MvcBeepoyEntities();

        protected int PageSize { get { return 10; } }

        private User user;

        
        public MvcBeepoyEntities Db { get { return db; } }

        public User SessionUser{
            get
            {
                if (user == null)
                    user = (User) this.HttpContext.Session["User"];
                return user;
            }
            set
            {
                this.HttpContext.Session.Add("User", value);
                user = value;
            }

        }


        //
        // GET: /App/

        //public ActionResult Index()
        //{
        //    return View();
        //}

    }
}
