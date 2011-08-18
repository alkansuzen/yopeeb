using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace TesteNhibernate.Models
{
    public class GenreMap:ClassMap<User>
    {
        public GenreMap()
        {
            Table("Users");

            //Id(x => x.Id);
            Id(x => x.Id);
            Map(x => x.Name);
            
        }
    }
}