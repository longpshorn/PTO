using System.Collections.Generic;
using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class Layout : AuditEntity<Layout, int>
    {
        public string Name { get; set; }
        public string HtmlContent { get; set; }
        public virtual ICollection<LayoutSection> LayoutSections { get; set; }
    }
}
