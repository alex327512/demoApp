using StudyingProgect.ApplicationCore.Entities;

namespace StudyingProgect.ApplicationCore.Models
{
    public class Nomenclature : Catalog
    {
        public string Description { get; set; }

        public Nomenclature(string description) : this()
        {
            Description = description;
        }

        public Nomenclature() : base()
        {
        }
    }
}
