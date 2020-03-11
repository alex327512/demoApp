using System;

namespace StudyingProgect.ApplicationCore.Entity
{
    public abstract class Document : EntityBase
    {
        public DateTime Date { get; set; }

        protected Document(DateTime? date = null) : base()
        {
            Date = date ?? DateTime.Now;
        }
    }
}
