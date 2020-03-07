using StudyingProgect.ApplicationCore.Entity;
using StudyingProgect.ApplicationCore.Models;
using System;
using System.Collections.Generic;

namespace StudyingProgect.ApplicationCore
{
    public class Incoming : Document
    {
        public Warehouse Warehouse { get; set; }

        public List<LineItem> ListOfNomenc { get; set; }

        public Incoming(DateTime? date = null) : base(date)
        {
            ListOfNomenc = new List<LineItem>();
        }

        public void Write()
        {
            ////foreach (var item in ListOfNomenc)
            ////{
            ////    var remain = new RemainNomenclature();
            ////    remain.Nomenclature = item.Nomenclature;
            ////    remain.Warehouse = this.Warehouse;
            ////    remain.Quantity = item.Quantity;
            ////    remain.Date = this.Date;
            ////    remain.RecordType = RecordType.Receipt;
            ////    State.RemainNomenclature.Add(remain);
            ////}
        }
    }
}
