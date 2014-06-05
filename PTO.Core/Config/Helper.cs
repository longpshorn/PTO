using System.Collections.Generic;
using System.Xml.XPath;

namespace PTO.Core.Config
{
    public class IdValueDictionary : Dictionary<string, string>
    {
        public IdValueDictionary() { }

        public IdValueDictionary(IEnumerable<KeyValuePair<string, string>> dictionary)
        {
            if (dictionary != null)
            {
                foreach (var entry in dictionary)
                {
                    Add(entry.Key, entry.Value);
                }
            }
        }

        public void Init(XPathNodeIterator iter)
        {
            Clear();

            while (iter.MoveNext())
            {
                string id = iter.Current.GetAttribute("id", string.Empty);
                string value = iter.Current.GetAttribute("value", string.Empty);

                this[id] = value;
            }
        }
    }
}
