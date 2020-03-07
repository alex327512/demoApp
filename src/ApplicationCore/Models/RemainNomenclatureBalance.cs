﻿using System;

namespace StudyingProgect.ApplicationCore.Models
{
    public class RemainNomenclatureBalance
    {
        public DateTime Date { get; set; }

        public Nomenclature Nomenclature { get; set; }

        public Warehouse Warehouse { get; set; }

        public decimal Quantity { get; set; }
    }
}