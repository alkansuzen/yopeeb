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
    
    public partial class BeepsPlace
    {
        // Primitive properties
    
        public long BeepId { get; set; }
        public long PlaceId { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
    
        // Navigation properties
    
        public virtual Beep Beep { get; set; }
        public virtual Place Place { get; set; }
    
    }
}
