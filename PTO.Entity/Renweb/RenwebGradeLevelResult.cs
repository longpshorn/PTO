using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity.Renweb
{
    public class RenwebGradeLevelResult : AuditEntity<RenwebGradeLevelResult, int>
    {
        public string Gradelevel { get; set; }
    }
}
