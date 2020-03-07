using StudyingProgect.ApplicationCore.Entity;

namespace StudyingProgect.ApplicationCore.Models
{
    public class RemainNomenclature : Document
    {
        ////public DateTime Date { get; set; }

       ///// public Guid DocumentId { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public RecordType RecordType { get; set; }

        public decimal Quantity { get; set; }
    }

    public enum RecordType
    {
       Receipt,
       Expose
    }
}
