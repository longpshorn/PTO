using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity.Renweb
{
    public class RenwebSchoolResult : AuditEntity<RenwebSchoolResult, int>
    {
        public string Staff { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string Work { get; set; }

        public string Other { get; set; }

        public string Photo { get; set; }
    }
}
