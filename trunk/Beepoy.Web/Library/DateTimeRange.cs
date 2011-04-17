using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beepoy.Web.Library
{
    public class DateTimeRange
    {
        public DateTime DateTimeI { get; set; }
        public DateTime DateTimeF { get; set; }

        public DateTimeRange()
        {
        }

        public DateTimeRange(DateTime dateTimeI, DateTime dateTimeF)
        {
            this.DateTimeI = dateTimeI;
            this.DateTimeF = dateTimeF;
        }
    }
}