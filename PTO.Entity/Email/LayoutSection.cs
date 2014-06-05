using PTO.Core.Entities;

namespace PTO.Entity.Email
{
    public class LayoutSection : EntityBase<LayoutSection, int>
    {
        public string Name { get; set; }
        public virtual Layout Layout { get; set; }
        public bool IsGlobal { get; set; }
        public string HtmlContent { get; set; }
        public int SortOrder { get; set; }
    }
}