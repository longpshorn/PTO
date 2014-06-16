using Dapper;
using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure
{
    public partial class UserRepository : IUserRepository
    {
        public IQueryable<User> GetAllUsers()
        {
            var users = new List<User>();
            var factory = DbProviderFactories.GetFactory(Context.ProviderName);

            using (var connection = factory.CreateConnection())
            {
                connection.ConnectionString = Context.ProviderConnectionString;
                connection.Open();
                var sql = @"
select * from dbo.User a inner join dbo.Parent b on a.id = b.id
select * from dbo.User a inner join dbo.Student b on a.id = b.id";
                using (var multi = connection.QueryMultiple(sql))
                {
                    var parents = multi.Read<Parent>().ToList();
                    var students = multi.Read<Student>().ToList();

                    users.AddRange(parents);
                    users.AddRange(students);
                }
            }

            return users.AsQueryable();
        }
    }
}
