using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteNhibernate.Models;


namespace TesteNhibernate.Controllers
{
    public class AppController : Controller
    {
     
            public AppController()
                : this(new DataContext())
            {
            }
            public AppController(IDataContext dataContext)
            {
                this.DataContext = dataContext;
             
            }

            public IDataContext DataContext { get; set; }
        }
}

