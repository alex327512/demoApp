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


        public Incoming(DateTime? date = null)
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
                remain.Quantity = item.Quantity;
                remain.Date = this.Date;
                remain.RecordType = RecordType.Receipt;
                State.RemainNomenclature.Add(remain);
            }
        }
    }
}
