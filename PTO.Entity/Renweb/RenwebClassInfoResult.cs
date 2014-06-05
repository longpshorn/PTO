using PTO.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity.Renweb
{
    public class RenwebClassInfoResult : AuditEntity<RenwebClassInfoResult, int>
    {
        public int ClassID { get; set; }

        public string Subject { get; set; }
    }
}
