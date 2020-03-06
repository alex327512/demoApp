using System;

namespace StudyingProgect.ApplicationCore
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        protected EntityBase() => Id = Guid.NewGuid();
    }
}
