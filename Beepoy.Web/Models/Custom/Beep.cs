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

        public Place Place { get{
            return this.Place;
     
        } }


    }
}
