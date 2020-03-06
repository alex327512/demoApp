using StudyingProgect.ApplicationCore.Models;
using System.Collections.Generic;
using StudyingProgect.ApplicationCore.Entity;
using System;

namespace StudyingProgect.ApplicationCore
{
    public class Consumption : Document
    {
        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }

        public Consumption(DateTime? date = null) : base(date)
        {
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
