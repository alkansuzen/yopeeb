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
using System.Data.Entity;
    using System.Linq;
    
    public partial class Beep 
    {
        public Beep()
        {
            this.BeepsTags = new HashSet<BeepsTag>();
            this.Beeps = new HashSet<Beep>();
            this.EventId = -1;
            this.PlaceId = -1;
            this.BeepIdFather = -1;
            this.DateUpdate = DateTime.Now;
            this.DateInsert = DateTime.Now;
        }

        
    
        // Primitive properties
    
        public long BeepId { get; set; }
        public string Text { get; set; }
        public long UserId { get; set; }
        public long EventId { get; set; }
        public long PlaceId { get; set; }
        public long BeepIdFather { get; set; }
        public System.DateTime DateInsert { get; set; }
        public System.DateTime DateUpdate { get; set; }
      
            
        // Navigation properties
    
        public virtual ICollection<BeepsTag> BeepsTags { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<Beep> Beeps { get; set; }
        public virtual Beep BeepFather { get; set; }
        public virtual Place Place { get; set; }
        public virtual User User { get; set; }
        public virtual DbSet<Beep> DbBeeps { get; set; }

        public IEnumerable<string> GetTagsFromText()
        {
            return this.Text.Split(' ').Where(t => t.ToString().IndexOf('#') == 0);
        }

        public IEnumerable<string> GetPlacesFromText()
        {
            return this.Text.Split(' ').Where(t => t.ToString().IndexOf('$') == 0);
        }

        public IEnumerable<string> GetEventsFromText()
        {
            return this.Text.Split(' ').Where(t => t.ToString().IndexOf('&') == 0);
        }

        public IEnumerable<string> GetUsersFromText()
        {
            return this.Text.Split(' ').Where(t => t.ToString().IndexOf('@') == 0);
        }
    }
}
