using StudyingProgect.ApplicationCore.Entities.Catalogs;
using static StudyingProgect.ApplicationCore.Enums.WriteOffMethod;

namespace StudyingProgect.ApplicationCore.Entities.Registers.Information
{
    public class AccountingPolicy : InformationRegister
    {
        public Warehouse Warehouse { get; set; }
        public WriteMethod WriteMethod { get; set; }
    }
}
