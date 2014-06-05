using PTO.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PTO.Infrastructure.Mapping
{
    public class ParentMap : EntityTypeConfiguration<Parent>
    {
        public ParentMap()
        {
            ToTable("Parent");

            Ignore(x => x.Children);
        }
    }
}
