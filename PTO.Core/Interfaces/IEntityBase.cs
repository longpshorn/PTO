﻿namespace PTO.Core.Interfaces
{
    public interface IEntityBase<TKey>
        where TKey : struct
    {
        TKey Id { get; set; }
    }
}
