using System;

namespace AorangiPeak.Domain.Core.Model
{
    public interface IEntity<T>
    {
        T Id { get; }
    }

    public interface IEntity
    {
        Guid Id { get; }
    }
}
