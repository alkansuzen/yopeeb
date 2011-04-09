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

        public MvcBeepoyEntities Db{ 
                 get{
                    return db;
                 }
        }

        //
        // GET: /App/

        public ActionResult Index()
        {
            return View();
        }

    }
}
