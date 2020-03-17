using System;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class Register
    {
        protected Register(DateTime? date = null) : base()
        {
            Date = date ?? DateTime.Now;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

    }
}
