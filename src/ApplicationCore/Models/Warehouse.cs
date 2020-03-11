using StudyingProgect.ApplicationCore.Entities;

namespace StudyingProgect.ApplicationCore.Models
{
    public class Warehouse : Catalog
    {

        public string Description { get; set; }

        public Warehouse(string description) : base()
        {
            Description = description;
        }
    }
}
