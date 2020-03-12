using System;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entities.Catalogs;

namespace StudyingProgect.ApplicationCore.Entities.Documents
{
    public class Incoming : Document
    {
        public Incoming(DateTime? date = null) : base(date)
        {
            ListOfNomenc = new List<LineItem>();
        }

        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }
    }
}
