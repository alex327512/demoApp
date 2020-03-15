using System;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class Register
    {
        public Guid Id { get; set; }

        protected Register() => Id = Guid.NewGuid();
    }
}
