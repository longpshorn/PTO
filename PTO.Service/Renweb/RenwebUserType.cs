using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PTO.Service.Renweb
{
    public enum RenwebUserType
    {
        [Description("PARENT")]
        Parent = 1,

        [Description("FACULTY")]
        Faculty = 2
    }
}