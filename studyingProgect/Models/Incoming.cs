using studyingProgect.Models;
using System;
using System.Collections.Generic;

namespace studyingProgect
{
    public class Incoming
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public Warehouse Warehouse { get; set; }
        public List<LineItem> ListOfNomenc { get; set; }


        public Incoming(string description)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            ListOfNomenc = new List<LineItem>();
        }
    }
}
