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
    
    public partial class Tag
    {
        public Tag()
        {
            this.BeepsTags = new HashSet<BeepsTag>();
            this.EventsTags = new HashSet<EventsTag>();
        }
    
        // Primitive properties
    
        public long TagId { get; set; }
        public string Text { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<BeepsTag> BeepsTags { get; set; }
        public virtual ICollection<EventsTag> EventsTags { get; set; }
    
    }
}