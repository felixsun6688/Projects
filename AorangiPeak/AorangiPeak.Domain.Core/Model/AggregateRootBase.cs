using System;

namespace AorangiPeak.Domain.Core.Model
{
    public abstract class AggregateRootBase : IAggregateRoot
    {
        public Guid Id { get; set; }
    }

    public abstract class AggregateRootBase<T> : IAggregateRoot<T>
    {
        public T Id { get; set; }
    }
}
