using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beepoy.Web.Library
{
    public class Coordinates
    {
        public double LatI { get; set; }
        public double LngI { get; set; }
        public double LatF { get; set; }
        public double LngF { get; set; }

        public Coordinates()
        {
        }

        public Coordinates(double latI, double lngI, double latF, double lngF)
        {
            this.LatI = latI;
            this.LngI = lngI;
            this.LatF = latF;
            this.LngF = lngF;
        }
    }
}