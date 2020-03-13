using StudyingProgect.ApplicationCore.Entities.Catalogs;
using static StudyingProgect.ApplicationCore.Enums.WriteOffMethod;

namespace StudyingProgect.ApplicationCore.Entities
{
    public abstract class InformationRegister : Register
    {
        public Warehouse Warehouse { get; set; }
        public WriteMethod WriteMethod { get; set; }
    }
}
