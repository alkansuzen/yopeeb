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
    
    public partial class EventsTag
    {
        // Primitive properties
    
        public long TagId { get; set; }
        public long EventId { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
    
        // Navigation properties
    
        public virtual Event Event { get; set; }
        public virtual Tag Tag { get; set; }
    
    }
}
