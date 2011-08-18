using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteNhibernate.Models;

namespace TesteNhibernate.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            var users = this.DataContext.Users.FindAll();

            return View(users);
        }

        public ActionResult Create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Create( User user)
        {
            this.DataContext.Users.Save(user);

            return new RedirectResult("index");

        }

        public ActionResult About()
        {
            return View();
        }
    }
}
