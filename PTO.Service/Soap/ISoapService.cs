using PTO.Service.Renweb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Service.Renweb
{
    public interface ISoapService
    {
        string CallSoapService(string url, string action);
    }
}
