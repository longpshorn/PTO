using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class TemplateSection : EntityBase<TemplateSection, int>
    {
        public string HtmlContent { get; set; }
        public virtual LayoutSection LayoutSection { get; set; }
        public virtual Template Template { get; set; }
    }
}
