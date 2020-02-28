using studyingProgect.Models;
using System;
using System.Collections.Generic;


namespace studyingProgect
{
    public class Assemblage
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Warehouse Warehouse { get; set; }
        public List<LineItem> ListOfNomenc { get; set; }


        public Assemblage()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;           
            ListOfNomenc = new List<LineItem>();
        }
    }
}
