using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteNhibernate.Models
{
    public class User
    {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
    }
}