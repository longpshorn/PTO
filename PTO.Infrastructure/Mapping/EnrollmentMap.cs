using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Infrastructure.Mapping
{
    public class EnrollmentMap : AuditEntityMap<Enrollment, int>
    {
        public EnrollmentMap()
            : base()
        {
            ToTable("Enrollment");

            HasRequired(x => x.Semester)
                .WithMany()
                .Map(x => x.MapKey("SemesterId"));

            HasRequired(x => x.Course)
                .WithMany(x => x.Enrollments)
                .Map(x => x.MapKey("CourseId"))
                .WillCascadeOnDelete();

            HasRequired(x => x.Student)
                .WithMany(x => x.Enrollments)
                .Map(x => x.MapKey("StudentId"))
                .WillCascadeOnDelete();
        }
    }
}
