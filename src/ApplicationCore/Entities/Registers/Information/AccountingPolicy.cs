using System;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using static StudyingProgect.ApplicationCore.Enums.WriteOffMethod;

namespace StudyingProgect.ApplicationCore.Entities.Registers.Information
{
    public class AccountingPolicy : InformationRegister
    {
        public AccountingPolicy(DateTime? date = null)
        {
            Date = date ?? DateTime.Now;
        }

        public DateTime Date { get; set; }
        public Warehouse Warehouse { get; set; }
        public WriteMethod WriteMethod { get; set; }
    }
}
