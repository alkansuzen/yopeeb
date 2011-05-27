using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteNhibernate.Models
{
    public interface IDataContext
    {
        
        IUserRepository Users { get; }
    }
}