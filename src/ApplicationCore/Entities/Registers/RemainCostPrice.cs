using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;

namespace StudyingProgect.ApplicationCore.Entities.Registers
{
    public class RemainCostPrice : Entity
    {
        public Nomenclature Nomenclature { get; set; }

        public Incoming Incoming { get; set; }

        public RecordType RecordType { get; set; }

        public decimal Amount { get; set; }

        public decimal Sum { get; set; }
    }
}
