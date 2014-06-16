using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        EntityConnectionStringBuilder _builder;
        private EntityConnectionStringBuilder EntityConnStrBuilder
        {
            get
            {
                if (_builder == null)
                {
                    _builder = new EntityConnectionStringBuilder(((IObjectContextAdapter)this).ObjectContext.Connection.ConnectionString);
                    if (!string.IsNullOrWhiteSpace(_builder.Name))
                    {
                        //    _builder = new EntityConnectionStringBuilder(
                        //        ConfigurationManager.ConnectionStrings[_builder.Name].ConnectionString);
                    }
                }
                return _builder;
            }
        }

        public string ProviderName
        {
            get { return EntityConnStrBuilder.Provider; }
        }

        public string ProviderConnectionString
        {
            get { return EntityConnStrBuilder.ProviderConnectionString; }
        }
    }
}
