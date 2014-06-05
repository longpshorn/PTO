using System.Collections.Generic;
using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class Template : AuditEntity<Template, int>
    {
        public string Name { get; set; }
        public virtual Layout Layout { get; set; }
        public string Subject { get; set; }
        public string TextContent { get; set; }
        public bool IsActive { get; set; }
        public virtual TemplateType Type { get; set; }
        public virtual ICollection<TemplateSection> TemplateSections { get; set; }
    }
}
