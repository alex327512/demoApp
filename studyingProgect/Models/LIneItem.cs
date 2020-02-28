using studyingProgect.Models;


namespace studyingProgect
{
    public class LineItem
    {
        public Nomenclature Nomenclature { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
