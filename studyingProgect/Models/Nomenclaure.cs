using System;

namespace studyingProgect.Models
{
    public class Nomenclaure
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Nomenclaure(string description)
        {
            Id = Guid.NewGuid();
            Description = description;
        }
    }
}
