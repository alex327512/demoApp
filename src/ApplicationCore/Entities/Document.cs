using System;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class Document : Entity
    {
        public DateTime Date { get; set; }

        protected Document(DateTime? date = null) : base()
        {
            Date = date ?? DateTime.Now;
        }
    }
}
