﻿using Base.Domain.Contracts;

namespace Base.Domain;

public abstract class DomainEntityId : DomainEntityId<Guid>, IDomainEntityId
{
    
}

public abstract class DomainEntityId<TKey> : IDomainEntityId<TKey>
    where TKey: struct, IEquatable<TKey>
{
    public virtual TKey Id { get; set; }
}