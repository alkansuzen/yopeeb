using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beepoy.Web.Models;
using Beepoy.Web.Filters;
using System.Configuration;
using TweetSharp;
using TweetSharp.Model;

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
        public ActionResult Streams()
        {

            List<Beep> beeps;

            DateTime lastQueryDate = DateTime.Now;

            if (this.Request.IsAjaxRequest())
            {
                if (this.HttpContext.Session["lastQuery"] == null)
                {
                    beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert < lastQueryDate);
                }
                else
                {
                    DateTime lastResult = (DateTime)this.HttpContext.Session["lastQuery"];
                    beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert > lastResult);
                }
            }
            else
            {
                beeps = SessionUser.FollowingBeeps(beep => beep.DateInsert < lastQueryDate, 6);
                //return PartialView("");
            }

            this.HttpContext.Session.Add("lastQuery", lastQueryDate);

            return PartialView(beeps);
        }

        public ActionResult Authorization()
        {
            twitterService = new TwitterService(
                ConfigurationManager.AppSettings["ConsumerKey"] 
                , ConfigurationManager.AppSettings["ConsumerSecret"] 
                , ConfigurationManager.AppSettings["AccessToken"]
                , "");

            //Now we need the Token and TokenSecret
            //Firstly we need the RequestToken and the AuthorisationUrl
            requestToken = twitterService.GetRequestToken();
            string authUrl = twitterService.GetAuthorizationUri(requestToken).AbsoluteUri;

            return new RedirectResult(authUrl);
        }

        public ActionResult /*string*/ Authentication(string oauth_token, string oauth_verifier)
        {
            //OAuthAccessToken accessToken = twitterService.GetAccessToken(requestToken, oauth_verifier);
            OAuthAccessToken accessToken = twitterService.GetAccessToken(requestToken);

            twitterService.AuthenticateWith(accessToken.Token, accessToken.TokenSecret);

            //TwitterStatus twitterStatus = twitterService.SendTweet("tweet or beep ?");
            //if (twitterService.Response.InnerException != null)
            //    return "erro";
            //return "ok";

            TwitterUser twitterUser = twitterService.GetUserProfile();

            try
            {
                SessionUser = Db.Users.First(usr => usr.IdName == twitterUser.ScreenName);
            }
            catch(System.InvalidOperationException exc)
            {
                Beepoy.Web.Models.User usr = new Beepoy.Web.Models.User
                {
                    UserName = twitterUser.Name
                    , IdName = twitterUser.ScreenName
                    , ImageUrl = twitterUser.ProfileImageUrl
                    , DateInsert = DateTime.Now
                    , DateUpdate = DateTime.Now
                    , Password = ""
                };

                Db.Users.Add(usr);
                Db.SaveChanges();

                SessionUser = usr;
            }

            //return SessionUser.UserName;
            return new RedirectResult("/");
            //return View();
        }

        public ActionResult Logout()
        {
            twitterService.EndSession();

            return new RedirectResult("/");
        }

        public string Tweet()
        {
            TwitterStatus twitterStatus = twitterService.SendTweet("beep or tweet?");
            return twitterStatus.Text;
        }
    }
}
