using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beepoy.Web.Controllers
{
    public class BeepsController : AppController
    {
        //
        // GET: /Beeps/

        public ActionResult Index()
        {
            return View();
        }

    }
}
