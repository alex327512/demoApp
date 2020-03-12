using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Documents
{
    public class LineItem
    {
        public Nomenclature Nomenclature { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Sum { get; set; }
    }
}
