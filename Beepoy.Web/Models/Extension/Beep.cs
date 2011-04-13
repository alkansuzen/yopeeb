using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Beepoy.Web.Models
{
    public static class BeepExt 
    {
        public static IQueryable<Beep> ByPlace<T>(this DbSet<T> beeps, long placeId) where T : Beep
        {
            var context = new MvcBeepoyEntities();

            return  beeps.Join(context.BeepsPlaces,
                         b => b.BeepId,
                         bp => bp.BeepId, (b, bp) => bp).Where(bp => bp.PlaceId == placeId)
                         .Select( (b,t) => b.Beep);

        }

        public static IQueryable<Beep> ByEvent<T>(this DbSet<T> beeps, long eventId) where T : Beep
        {
            var context = new MvcBeepoyEntities();

            return beeps.Join(context.BeepsEvents,
                         b => b.BeepId,
                         be => be.BeepId, (b, be) => be).Where(be => be.EventId == eventId)
                         .Select((b, t) => b.Beep);
        }

        public static IQueryable<Beep> ByUser<T>(this DbSet<T> beeps, long userId) where T : Beep
        {
            var context = new MvcBeepoyEntities();

            return (DbSet<T>)beeps.Join(context.BeepsUsers,
                         b => b.UserId,
                         bu => bu.UserId, (b, bu) => bu).Where(bu => bu.UserId == userId)
                         .Select((b, t) => b.Beep);

        }
  
  
    }
}
