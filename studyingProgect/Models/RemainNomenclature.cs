using System;
using System.Collections.Generic;
using System.Text;

namespace studyingProgect.Models
{
    public class RemainNomenclature
    {
        public DateTime Date { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public RecordType RecordType { get; set; }

        public decimal Quantity { get; set; }
    }

    public enum RecordType
    {
       Receipt,
       Expose
    }
}
