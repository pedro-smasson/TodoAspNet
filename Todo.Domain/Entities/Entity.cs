using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity() 
            => Id = Guid.NewGuid();

        public bool Equals(Entity otherEntity)
            => Id == otherEntity.Id;

        public Guid Id { get; private set; }
    }
}