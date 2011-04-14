using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;

namespace Beepoy.Web.Controllers
{
    public class PlacesController : AppController
    {
        //
        // GET: /Places/

        public ActionResult Index(int Page)
        {
            var places = Db.Places.OrderBy(p => p.DateInsert).Skip(Page).Take(this.PageSize);

            return View();
        }

        //
        // GET: /Places/Details/5

        public ActionResult Details(int id)
        {
            var place = Db.Places.Find(id);

            return View(place);
        }

        //
        // GET: /Places/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Places/Create

        [HttpPost]
        public ActionResult Create(Place place)
        {
            try
            {
                // TODO: Add insert logic here

                Db.Places.Add(place);
                Db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Places/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Places/Edit/5

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
        // GET: /Places/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Places/Delete/5

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
        // GET: /Places/Beeps

        public ActionResult Beeps(int Page = 0, int PlaceId = 0)
        {
            //Get Beeps from PlaceId
            var beeps = Db.Beeps.ByPlace(PlaceId)
                .OrderByDescending(b => b.DateInsert)
                .Skip(Page)
                .Take(this.PageSize);
           
            return View(beeps);
        }

        //
        // GET: /Places/TopTrend

        public ActionResult ToTrend()
        {
            //Get Beeps from PlaceId
            var places = Db.Places
                .OrderByDescending(b => b.DateInsert)
                .Skip(8);

            return View(places);
        }
    }
}
