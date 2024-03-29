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
    
    public partial class Beep
    {
        public Beep()
        {
            this.BeepsTags = new HashSet<BeepsTag>();
            this.Beeps = new HashSet<Beep>();
            this.BeepsEvents = new HashSet<BeepsEvent>();
            this.BeepsPlaces = new HashSet<BeepsPlace>();
            this.BeepsUsers = new HashSet<BeepsUser>();
        }
    
        // Primitive properties
    
        public long BeepId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public long BeepIdFather { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
        public System.DateTime DateWhen { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<BeepsTag> BeepsTags { get; set; }
        public virtual ICollection<Beep> Beeps { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<BeepsEvent> BeepsEvents { get; set; }
        public virtual ICollection<BeepsPlace> BeepsPlaces { get; set; }
        public virtual ICollection<BeepsUser> BeepsUsers { get; set; }
    
    }
}
