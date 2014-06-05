using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace PTO.Core.Email
{
    public static class EmailSource
    {
        private const string OuterNodeName = "/EmailTypes/";
        private const string TypeName = "TypeName";
        private const string ModelType = "ModelType";
        private const string ModelTypeName = "ModelTypeName";
        private const string IsSolicited = "IsSolicited";

        /// <summary>
        /// Gets a list of email types - this is used by T4 templates to generate classes
        /// </summary>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        public static IList<EmailTypeDescriptor> GetEmailTypes(EmailSourceType sourceType)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (System.IO.Stream file = assembly.GetManifestResourceStream("PTO.Core.Email.EmailTypes.xml"))
            {
                if (file == null)
                {
                    return null;
                }

                var document = new XmlDocument();
                document.Load(file);

                var result = new List<EmailTypeDescriptor>();

                var nodes = document.SelectNodes(OuterNodeName + Enum.GetName(typeof(EmailSourceType), sourceType));

                if (nodes == null)
                {
                    return null;
                }

                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes == null)
                    {
                        continue;
                    }

                    string emailType = string.Empty;

                    XmlAttribute attr = node.Attributes[TypeName];
                    if (attr != null)
                    {
                        emailType = attr.InnerText;
                    }
                    else
                    {
                        throw new ApplicationException("Could not fetch email type for email sourceType: " + sourceType);
                    }

                    attr = node.Attributes[ModelType];
                    string modelType = attr != null ? attr.InnerText : emailType;

                    attr = node.Attributes[ModelTypeName];
                    string modelTypeName = attr != null ? attr.InnerText : emailType;

                    attr = node.Attributes[IsSolicited];
                    bool isSolicited = attr != null && attr.InnerText.Equals("true", StringComparison.CurrentCultureIgnoreCase);

                    result.Add(new EmailTypeDescriptor(emailType, modelType, modelTypeName, isSolicited));
                }

                return result;
            }
        }
    }
}
