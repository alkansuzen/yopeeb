//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Beepoy.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Place
    {
        public Place()
        {
            this.Events = new HashSet<Event>();
            this.TrackUserPlaces = new HashSet<TrackUserPlace>();
            this.BeepsPlaces = new HashSet<BeepsPlace>();
        }
    
        // Primitive properties
    
        public long PlaceId { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long UserId { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public string IdName { get; set; }
        public string Description { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<TrackUserPlace> TrackUserPlaces { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BeepsPlace> BeepsPlaces { get; set; }
    
    }
}