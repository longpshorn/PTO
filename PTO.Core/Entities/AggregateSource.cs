using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;

namespace PTO.Core.Entities
{
    public class AggregateSource
    {
        // Aggregate source file settings
        private const string _aggregatesSource = "PTO.Core.Entities.Aggregates.xml";
        private const string _outerNodeName = "/Aggregates/Aggregate";

        // Aggregate keys
        private const string _entityNameKey = "EntityName";
        private const string _entityKeyTypeKey = "KeyType";
        private const string _entitySetKey = "EntitySet";
        private const string _entityContextKey = "EntityContext";

        // Aggregate defaults
        private const string _defaultKeyTypeValue = "int";
        private const string _defaultEntitySetValue = "s";
        private const string _defaultContextValue = "AppContext";

        private static IEnumerable<AggregateDescriptor> _aggregates;

        public static IEnumerable<AggregateDescriptor> GetAggregates()
        {
            if (_aggregates != null)
            {
                return _aggregates;
            }

            var assembly = Assembly.GetExecutingAssembly();
            using (Stream file = assembly.GetManifestResourceStream(_aggregatesSource))
            {
                // Missing aggregate source
                if (file == null)
                {
                    Debug.Print("Warning: Could not find aggregate source file: {0}.  Ensure the source file has been configured as an Embedded Resource.", _aggregatesSource);
                    return null;
                }

                var document = new XmlDocument();
                document.Load(file);

                var nodes = document.SelectNodes(_outerNodeName);
                // Make sure the aggregate source has some aggregates
                if (nodes == null)
                {
                    Debug.Print("Warning: Could not find any aggregates in the aggregate source file: {0}.", _aggregatesSource);
                    return null;
                }

                var result = new List<AggregateDescriptor>();
                foreach (XmlNode node in nodes)
                {
                    // Skip node if it doesn't have any attributes
                    if (node.Attributes == null)
                    {
                        Debug.Print("Warning: Aggregate from aggregate source is not correctly configured. Missing aggregate entity name.");
                        continue;
                    }

                    // Get the name of the entity
                    XmlAttribute attr = node.Attributes[_entityNameKey];
                    string entityName = attr != null
                        ? attr.InnerText
                        : string.Empty;
                    if (string.IsNullOrEmpty(entityName))
                    {
                        Debug.Print("Warning: Aggregate from aggregate source is not correctly configured. Missing aggregate entity name.");
                        throw new ApplicationException("Could not fetch entity name");
                    }

                    // Get the entity key for this aggregate
                    attr = node.Attributes[_entityKeyTypeKey];
                    string keyType = attr != null
                        ? attr.InnerText
                        : _defaultKeyTypeValue;

                    // Get the entity set for this aggregate
                    attr = node.Attributes[_entitySetKey];
                    string entitySet = attr != null
                        ? attr.InnerText
                        : string.Concat(entityName, _defaultEntitySetValue);

                    // Get the entity context for this aggregate
                    attr = node.Attributes[_entityContextKey];
                    string entityContext = attr != null
                        ? attr.InnerText
                        : _defaultContextValue;

                    // Add the new aggregate descriptor to the source list.
                    result.Add(new AggregateDescriptor(entityName, keyType, entitySet, entityContext));
                }

                _aggregates = result;
                Debug.Assert(result != null);

                return _aggregates;
            }
        }
    }
}
