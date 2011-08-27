using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;
using Beepoy.Web.Library;
using Beepoy.Web.Filters;

namespace Beepoy.Web.Controllers
{
    public class BeepsController : AppController
    {
        //
        // GET: /Beeps/

        public ActionResult Index(int Page = 0, int UserId = 0)
        {
            //Get Beeps from UserId
            var beeps = Db.Beeps
                        .Where(p => (p.UserId == UserId))
                        .OrderBy(b => b.DateInsert)
                        .Skip(Page)
                        .Take(this.PageSize);

            return View(beeps);
        }

        //
        // GET: /Beeps/Details/5

        public ActionResult Details(int id)
        {
            var beep = Db.Beeps.Find(id);

            IEnumerable<string> s = null;

            //s = beep.GetTagsFromText();
            //s = beep.GetPlacesFromText();
            //s = beep.GetEventsFromText();
            //s = beep.GetUsersFromText();

            return View(beep);
        }

        //
        // GET: /Beeps/Create

        public ActionResult Create()
        {

            ViewBag.PlaceId = new SelectList(Db.Places, "PlaceID", "Name");
            return View();
        } 

        //
        // POST: /Beeps/Create
        [AuthorizeFilter]
        [HttpPost]
        public String Create(Beep beep, Place place)
        {
            try
            {
                // TODO: Add insert logic here

                beep.User = Db.Users.Find(SessionUser.UserId);
                beep.BeepIdFather = -1;
                beep.DateInsert = DateTime.Now;
                beep.DateUpdate = DateTime.Now;
                
                System.Globalization.DateTimeFormatInfo dtfi = new System.Globalization.DateTimeFormatInfo();
                dtfi.ShortDatePattern = "MM-dd-yyyy";
                dtfi.DateSeparator = "-";
                beep.DateWhen = Convert.ToDateTime(Request["DateWhen"], dtfi);

                place.IdName = place.Latitude.ToString() + "," + place.Longitude.ToString();
                place.Latitude = Convert.ToDouble(Request["Latitude"]);
                place.Longitude = Convert.ToDouble(Request["Longitude"]);
                place.Name = "-";
                place.Description = Request["Address"].ToString();
                place.User = Db.Users.Find(SessionUser.UserId);
                place.ImageUrl = "";
                place.DateInsert = DateTime.Now;
                place.DateUpdate = DateTime.Now;

                BeepsPlace bp = new BeepsPlace
                {
                    PlaceId = place.PlaceId,
                    Beep = beep,
                    DateInsert = DateTime.Now,
                    DateUpdate = DateTime.Now
                };

                Db.Beeps.Add(beep);
                Db.Places.Add(place);
                Db.BeepsPlaces.Add(bp);

                Db.SaveChanges();

                TwitterService.SendTweet(beep.Text);

                return "Sucess";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return e.Message + e.StackTrace + e.InnerException.Message;
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

        public ActionResult List(int Page = 0, int BeepIdFather = 0)
        {
            //Get Beeps from BeepIdFather
            var beeps = Db.Beeps
                .Where(b => (b.BeepIdFather == BeepIdFather))
                .OrderByDescending(b => b.DateInsert)
                .Skip(Page)
                .Take(this.PageSize);

            return View(beeps);
        }

        //
        // GET: /Beeps/Beeps
        [HttpPost]
        public ActionResult ListByCoordsAndDateTime(Coordinates coords, DateTimeRange dateTimeRange)
        {
            //Get Beeps from Place Coordinates
            //var beeps = Db.Beeps.ByDateTimeRange(dateTimeRange);//.ByCoordinates(coords);
            var beeps = Db.Beeps.ByCoordinates(Db, coords);

            return View(beeps);
        }

        //[HttpPost]
        //public string ListByCoordsAndDateTime(Coordinates coordinates, DateTimeRange dateTimeRange)
        //{
        //    string s = coordinates.LatF.ToString() + dateTimeRange.DateTimeF.ToString();
        //    return s;
        //}
    }
}
