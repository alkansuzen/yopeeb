using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteNhibernate.Models
{
    public class UserRepository : NHibernateRepository<User>, IUserRepository
    {
    }
}