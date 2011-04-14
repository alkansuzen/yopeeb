using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;

namespace Beepoy.Web.Controllers
{
    public class EventsController : AppController
    {
        //
        // GET: /Events/

        public ActionResult Index(int Page)
        {
            var events = Db.Events.OrderBy(e => e.DateInsert).Skip(Page).Take(this.PageSize);

            return View();
        }

        //
        // GET: /Events/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Events/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Events/Create

        [HttpPost]
        public ActionResult Create(Event evnt)
        {
            try
            {
                // TODO: Add insert logic here

                Db.Events.Add(evnt);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Events/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Events/Edit/5

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
        // GET: /Events/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Events/Delete/5

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
        // GET: /Events/Beeps

        public ActionResult Beeps(int Page = 0, int EventId = 0)
        {
            //Get Beeps from EventId
            var beeps = Db.Beeps.ByEvent(EventId)
                .OrderByDescending(b => b.DateInsert)
                .Skip(Page)
                .Take(this.PageSize);

            return View(beeps);
        }
    }
}
