using System;

namespace StudyingProgect.ApplicationCore.Models
{
    public class Nomenclature
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Nomenclature(string description) : this()
        {
            Description = description;
        }

        public Nomenclature()
        {
            Id = Guid.NewGuid();
        }
    }
}
