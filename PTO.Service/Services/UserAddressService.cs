using PTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Service
{
    public partial class UserAddressService
    {
        public Dictionary<string, List<int>> GetFamilyAddresses()
        {
            var userAddresses = Repository
                .GetAll()
                .Where(x => x.Location != null)
                .Distinct()
                .ToList();

            var addresses = new Dictionary<string, List<int>>();
            userAddresses.ForEach(x =>
            {
                if (addresses.ContainsKey(x.Formatted))
                    addresses[x.Formatted].Add(x.Id);
                else
                    addresses.Add(x.Formatted, new List<int> { x.Id });
            });

            return addresses;
        }
    }
}
