using System;

namespace AorangiPeak.Domain.Core.Model
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }

    public abstract class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
    }
}
