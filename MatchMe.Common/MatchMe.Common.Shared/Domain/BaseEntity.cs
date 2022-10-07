﻿namespace MatchMe.Common.Shared.Domain
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; protected set; }
    }
}
