using System;

namespace studyingProgect.Models
{
    public class Warehouse
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Warehouse(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }
    }
}
