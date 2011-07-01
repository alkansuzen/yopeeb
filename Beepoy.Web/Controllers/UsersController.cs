using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;
using Beepoy.Web.Filters;

namespace Beepoy.Web.Controllers
{

   
    public class UsersController : AppController
    {
        //
        // GET: /Users/
        [AuthorizeFilter]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Users/Details/5

        public ActionResult Details(int id)
        {
            User user = Db.Users.Find(id);

            return View();
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Users/Beeps

        public ActionResult Beeps(int Page = 0, int UserId = 0)
        {
            //Get Beeps from UserId
            var beeps = Db.Beeps
                .Where(b => (b.UserId == UserId))
                .OrderByDescending(b => b.DateInsert)
                .Skip(Page)
                .Take(this.PageSize);

            return View(beeps);
        }

        public ActionResult Timeline()
        {

            return View();
        }


        //Todo:  Precisa arrumar o layout para exibir os beeps seguidos
        
        [AuthorizeFilter]
        public ActionResult Streams(){

            List<Beep> beeps;

            
                if (this.Request.IsAjaxRequest())
                {
                    if (this.HttpContext.Session["lastQuery"] == null)
                    {
                        beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert < DateTime.Now);
                    }
                    else
                    {
                        DateTime lastResult = (DateTime)this.HttpContext.Session["lastQuery"];
                        beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert > lastResult);
                    }
                }
                else
                {
                    beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert < DateTime.Now,6);
                }

                 this.HttpContext.Session.Add("lastQuery", DateTime.Now);
            
                return PartialView(beeps);
        }
    }
}
