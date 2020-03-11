using System;

namespace StudyingProgect.ApplicationCore
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity() => Id = Guid.NewGuid();
    }
}
