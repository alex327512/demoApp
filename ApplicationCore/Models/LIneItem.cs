using StudyingProgect.ApplicationCore.Models;


namespace StudyingProgect.ApplicationCore
{
    public class LineItem
    {
        public Nomenclature Nomenclature { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Sum { get; set; }
    }
}
