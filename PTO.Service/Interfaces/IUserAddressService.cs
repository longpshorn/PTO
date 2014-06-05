using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Service
{
    public partial interface IUserAddressService
    {
        Dictionary<string, List<int>> GetFamilyAddresses();
    }
}
