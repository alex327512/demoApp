using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Documents
{
    public class Assemblage : Document
    {
        public Assemblage(DateTime? date = null) : base(date)
        {
            ListOfNomenc = new List<LineItem>();
        }

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }
    }
}
