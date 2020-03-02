using System;
using System.Collections.Generic;
using System.Text;

namespace studyingProgect.Models
{
   public class History
    {


     

        public List<String> Warehouse { get; set; }
        public List<DateTime> Date { get; set; }

        public enum _IncOrCons { incoming = 1, consumption = 0 }


            public List<_IncOrCons> IncOrCons { get; set; }


        //public decimal Quantity { get; set; }
        // public Nomenclature Nomenclature { get; set; }
        public List<Nomenclature> Nomenclature { get; set; }
        public List<decimal> Quantity { get; set; }


        public History()
        {
            Nomenclature = new List<Nomenclature>();
            Warehouse = new List<String>();
            IncOrCons = new List<_IncOrCons>();
            Date = new List<DateTime>();
            Quantity = new List<decimal>();


        }

     
    }
}
