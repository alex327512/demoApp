using System.Collections.Generic;
using System;
using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Documents
{
    public class Consumption : Document
    {
        public Consumption(DateTime? date = null) : base(date)
        {
            ListOfNomenc = new List<LineItem>();
        }

        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }
    }

}
