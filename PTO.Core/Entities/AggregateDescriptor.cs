namespace PTO.Core.Entities
{
    public struct AggregateDescriptor
    {
        private readonly string _entityName;
        private readonly string _keyType;
        private readonly string _entitySet;
        private readonly string _entityContext;

        public AggregateDescriptor(string entityName, string keyType, string entitySet, string entityContext)
        {
            _entityName = entityName;
            _keyType = keyType;
            _entitySet = entitySet;
            _entityContext = entityContext;
        }

        public string EntityName { get { return _entityName; } }

        public string KeyType { get { return _keyType; } }

        public string EntitySet { get { return _entitySet;  } }

        public string EntityContext { get { return _entityContext; } }
    }
}
