using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Beepoy.Web.Library;

namespace Beepoy.Web.Models
{
    public static class BeepExt 
    {
        public static IQueryable<Beep> ByPlace<T>(this IQueryable<T> beeps, MvcBeepoyEntities db, long placeId) where T : Beep
        {
            return  beeps.Join(db.BeepsPlaces,
                         b => b.BeepId,
                         bp => bp.BeepId, (b, bp) => bp).Where(bp => bp.PlaceId == placeId)
                         .Select( (b,t) => b.Beep);
        }

        public static IQueryable<Beep> ByEvent<T>(this IQueryable<T> beeps, MvcBeepoyEntities db, long eventId) where T : Beep
        {
            return beeps.Join(db.BeepsEvents,
                         b => b.BeepId,
                         be => be.BeepId, (b, be) => be).Where(be => be.EventId == eventId)
                         .Select((b, t) => b.Beep);
        }

        public static IQueryable<Beep> ByUser<T>(this IQueryable<T> beeps, MvcBeepoyEntities db, long userId) where T : Beep
        {
            return (DbSet<T>)beeps.Join(db.BeepsUsers,
                         b => b.UserId,
                         bu => bu.UserId, (b, bu) => bu).Where(bu => bu.UserId == userId)
                         .Select((b, t) => b.Beep);
        }

        public static IQueryable<Beep> ByCoordinates<T>(this IQueryable<T> beeps, MvcBeepoyEntities context, Coordinates coords) where T : Beep
        {
            var result = from b in beeps
                         join bp in context.BeepsPlaces
                         on b.BeepId equals bp.BeepId
                         join p in context.Places
                         on bp.PlaceId equals p.PlaceId
                         where p.Latitude >= coords.LatI
                         select b;

            return result;
        }
        
        //context_.Beeps.ByCoordinates(coords).ByDateTime( dateimage).Whare( ).


        public static IQueryable<Beep> ByDateTimeRange<T>(this IQueryable<T> beeps, DateTimeRange dateTimeRange) where T : Beep
        {
            return beeps
                        .Where(b => b.DateInsert >= dateTimeRange.DateTimeI)
                        .Where(b => b.DateInsert <= dateTimeRange.DateTimeF);
        }
    }
}
