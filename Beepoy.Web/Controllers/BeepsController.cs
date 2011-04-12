using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;

namespace Beepoy.Web.Controllers
{
    public class BeepsController : AppController
    {
        //
        // GET: /Beeps/

        public ActionResult Index(int Page = 0, int UserId = 0)
        {
            //Get Beeps from UserId
            var beeps = Db.Beeps.Where(p => (p.UserId == UserId)).OrderBy(b => b.DateInsert).Skip(Page).Take(this.PageSize);

            return View(beeps);
        }

        //
        // GET: /Beeps/Details/5

        public ActionResult Details(int id)
        {
            var beep = Db.Beeps.Find(id);

            return View(beep);
        }

        //
        // GET: /Beeps/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Beeps/Create

        [HttpPost]
        public ActionResult Create(Beep beep)
        {
            try
            {
                // TODO: Add insert logic here
                Db.Beeps.Add(beep);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch( Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return View();
            }
        }
        
        //
        // GET: /Beeps/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Beeps/Edit/5

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
        // GET: /Beeps/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Beeps/Delete/5

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
        // GET: /Beeps/Beeps

        public ActionResult Beeps(int Page = 0, int BeepIdFather = 0)
        {
            //Get Beeps from BeepIdFather
            var beeps = Db.Beeps
                .Where(b => (b.BeepIdFather == BeepIdFather))
                .OrderByDescending(b => b.DateInsert)
                .Skip(Page)
                .Take(this.PageSize);

            return View(beeps);
        }
    }
}
