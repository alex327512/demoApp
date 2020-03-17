using System;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class AccumulationRegister : Register
    {


        public RecordType RecordType { get; set; }
    }
}
