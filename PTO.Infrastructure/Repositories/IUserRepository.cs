using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure
{
    public partial interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
    }
}
