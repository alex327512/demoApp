namespace StudyingProgect.ApplicationCore.Entities.Catalogs
{
    public class Nomenclature : Catalog
    {
        public Nomenclature(string description) : this()
        {
            Description = description;
        }

        public Nomenclature() : base()
        {
        }
        public string Description { get; set; }
    }
}
