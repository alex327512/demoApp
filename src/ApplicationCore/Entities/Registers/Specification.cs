using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Registers
{
    public class Specification : Catalog
    {
        public Nomenclature Kit { get; set; }

        public Nomenclature Component { get; set; }

        public decimal Amount { get; set; }

        public override bool Equals(object obj)
        {
            var o = obj as Specification;

            return Kit.Id == o.Kit.Id && Component.Id == o.Component.Id;
        }
    }
}
