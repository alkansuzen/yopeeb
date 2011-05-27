using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace TesteNhibernate.Models
{
    public class DataContext:IDataContext
    {
      
        public IUserRepository Users
        {
            get
            {
                return new UserRepository();
            }
        }
    }
}