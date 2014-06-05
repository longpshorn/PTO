using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTO.Entity.Renweb
{
    public static class RenwebStateLookpup
    {
        private static Dictionary<string, string> _stateMap = new Dictionary<string, string>
        {
            { "TX", "TX" },
            { "Tx", "TX" },
            { "Texas", "TX" },
            { "TEXAS", "TX" },
            { "AE", "AE" },
            { "NY", "NY" },
            { "CO", "CO" },
            { "IL", "IL" },
            { "Il", "IL" }
        };

        public static string Find(string key)
        {
            return _stateMap.ContainsKey(key)
                ? _stateMap[key]
                : null;
        }
    }
}
