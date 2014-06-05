using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping
{
    public class CourseMap : AuditEntityMap<Course, int>
    {
        public CourseMap()
        {
            ToTable("Course");

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Title");

            HasMany(x => x.Enrollments)
                .WithRequired(x => x.Course)
                .Map(x => x.MapKey("CourseId"));
        }
    }
}
