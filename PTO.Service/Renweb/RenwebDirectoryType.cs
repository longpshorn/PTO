using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PTO.Service.Renweb
{
    public enum RenwebDirectoryType
    {
        [Description("parent")]
        Parent = 1,

        [Description("student")]
        Student = 2,

        Faculty = 3
    }
}