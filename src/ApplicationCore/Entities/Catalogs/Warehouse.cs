namespace StudyingProgect.ApplicationCore.Entities.Catalogs
{
    public class Warehouse : Catalog
    {
        public Warehouse(string description) : base()
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
