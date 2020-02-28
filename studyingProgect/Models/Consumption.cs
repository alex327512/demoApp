using System;
using studyingProgect.Models;
using System.Collections.Generic;

namespace studyingProgect
{
    public class Consumption
    {

        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Warehouse Warehouse { get; set; }
        public List<LineItem> ListOfNomenc { get; set; }

        
        public Consumption()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            ListOfNomenc = new List<LineItem>();
            
        }


    }

}
