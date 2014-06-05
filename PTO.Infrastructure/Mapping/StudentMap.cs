using PTO.Entity;
using System.Data.Entity.ModelConfiguration;

namespace PTO.Infrastructure.Mapping
{
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            ToTable("Student");

            Ignore(x => x.Parents);

            HasMany(x => x.Enrollments)
                .WithRequired(x => x.Student)
                .Map(x => x.MapKey("StudentId"))
                .WillCascadeOnDelete();
        }
    }
}
