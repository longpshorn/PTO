namespace PTO.Core.Email
{
    public struct EmailTypeDescriptor
    {
        private readonly string _emailType;
        private readonly string _modelType;
        private readonly string _modelTypeName;
        private readonly bool _isSolicited;

        public EmailTypeDescriptor(string emailType, string modelType, string modelTypeName, bool isSolicited)
        {
            _emailType = emailType;
            _modelType = modelType;
            _modelTypeName = modelTypeName;
            _isSolicited = isSolicited;
        }

        public string EmailType { get { return _emailType; } }
        public string ModelType { get { return _modelType; } }
        public string ModelTypeName { get { return _modelTypeName; } }
        public string IsSolicited { get { return _isSolicited.ToString().ToLower(); } }
    }
}
