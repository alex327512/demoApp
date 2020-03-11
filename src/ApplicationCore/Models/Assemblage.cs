using StudyingProgect.ApplicationCore.Entities;
using StudyingProgect.ApplicationCore.Models;
using System;
using System.Collections.Generic;


namespace StudyingProgect.ApplicationCore
{
    public class Assemblage : Document
    {
        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }

        public Assemblage(DateTime? date = null) : base(date)
        {
            ListOfNomenc = new List<LineItem>();
        }
    }
}
