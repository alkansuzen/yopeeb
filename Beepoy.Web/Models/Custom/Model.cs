using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beepoy.Web.Models
{
    public class Model
    {
        private MvcBeepoyEntities context = new MvcBeepoyEntities();

        public MvcBeepoyEntities Context {
            get {
                return this.context;
            }
        }


    }
}