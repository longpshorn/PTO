using PTO.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PTO.Web.Models
{
    public class EmailViewModel
    {
        public string Address { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsActive { get; set; }

        public EmailType Type { get; set; }
    }
}
