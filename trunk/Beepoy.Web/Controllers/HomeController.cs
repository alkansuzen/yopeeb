﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;

namespace Beepoy.Web.Controllers
{
    public class HomeController : Controller
    {
        MvcBeepoyEntities db = new MvcBeepoyEntities();

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            //User user = new User()
            //{
            //    UserName = "Rodrigo",
            //    Password = "senha",
            //    DateInsert = DateTime.Now,
            //    DateUpdate = DateTime.Now
            //};
            //db.Users.Add(user);
            //db.SaveChanges();

            //Place place = new Place()
            //{
            //    User = user,
            //    Latitude = 3428947294,
            //    Longitude = 3428746287,
            //    Name = @"Parque",
            //    DateInsert = DateTime.Now,
            //    DateUpdate = DateTime.Now
            //};
            //db.Places.Add(place);
            //db.SaveChanges();

            //Event event1 = new Event()
            //{
            //    Place = db.Places.Find(1),
            //    Text = "InterUnesp",
            //    User = db.Users.Find(1),
            //    DateInsert = DateTime.Now,
            //    DateUpdate = DateTime.Now
            //};
            //db.Events.Add(event1);
            //db.SaveChanges();

            //Beep beep = new Beep()
            //{
            //    Text = "O quê? Onde? Quando?",
            //    Event = db.Events.Find(3),
            //    User = db.Users.Find(1),
            //    BeepFather = db.Beeps.Find(6),
            //    DateInsert = DateTime.Now,
            //    DateUpdate = DateTime.Now
            //};
            //db.Beeps.Add(beep);
            //db.SaveChanges();

            TrackUserUser t = new TrackUserUser()
            {
                User = db.Users.Find(1),
                UserTracked = db.Users.Find(4),
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now
            };
            db.TrackUserUsers.Add(t);
            db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}