using System;

namespace PTO.Core.Interfaces
{
    public interface IAuditEntity
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int UpdatedBy { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
