using System;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class Register
    {
        protected Register() : base()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        ///убрать
    }
}
