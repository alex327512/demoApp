using System;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class AccumulationRegister : Register
    {
        protected AccumulationRegister(DateTime? date = null) {
            Date = date ?? DateTime.Now;
        }

        public DateTime Date { get; set; }
        public RecordType RecordType { get; set; }
    }
}
