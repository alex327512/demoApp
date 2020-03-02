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

        
        public Consumption(DateTime? date = null)
        {
            Id = Guid.NewGuid();
            Date = date??DateTime.Now;
            ListOfNomenc = new List<LineItem>();
            
        }

        public void Write()
        {
            foreach (var item in ListOfNomenc)
            {
                var remain = new RemainNomenclature();
                remain.Nomenclature = item.Nomenclature;
                remain.Warehouse = this.Warehouse;
                remain.Date = this.Date;
                remain.Quantity = item.Quantity;
                remain.RecordType = RecordType.Expose;
                State.RemainNomenclature.Add(remain);
            }
        }
    }

}
