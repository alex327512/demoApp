using System;
using System.Collections.Generic;
using System.Text;

namespace studyingProgect.Models
{
   public class History
    {


        public List<LineItem> ListOfNomenc { get; set; }

        public Warehouse Warehouse { get; set; }

        public enum IncOrCons  {Inc = 1, Cons = 0}

        public decimal Quantity { get; set; }

        public History()
        {

            ListOfNomenc = new List<LineItem>();
        }

     
    }
}
