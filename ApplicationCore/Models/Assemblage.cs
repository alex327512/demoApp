using StudyingProgect.ApplicationCore.Models;
using System;
using System.Collections.Generic;


namespace StudyingProgect.ApplicationCore
{
    public class Assemblage
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Warehouse Warehouse { get; set; }
        public List<LineItem> ListOfNomenc { get; set; }


        public Assemblage(DateTime? date = null)
        {
            Id = Guid.NewGuid();
            Date = date??DateTime.Now;           
            ListOfNomenc = new List<LineItem>();
        }
    }
}
