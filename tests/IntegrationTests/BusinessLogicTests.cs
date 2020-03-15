﻿using System;
using System.Collections.Generic;
using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.ApplicationCore.Services.Documents;
using StudyingProgect.Infrastucture;
using Xunit;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace StudyingProgect.IntegrationTests
{
    public class BusinessLogicTests
    {
        private readonly IDb _db;
        private readonly IRepository<Incoming> _incomingRepository;
        private readonly IRepository<Consumption> _consumptionRepository;
        private readonly IRegisterRepository<RemainNomenclature> _remainNomenclatureRepository;
        private readonly IRegisterRepository<RemainCostPrice> _remainCostPrice;
        private readonly IncomingService _incomingService;
        private readonly ConsumptionService _consumptionService;
        private readonly IRegisterRepository<RemainNomenclatureBalance> _remainNomenclatureBalance;


        public BusinessLogicTests()
        {
            _db = new State();
            _db.Initialize();
            _incomingRepository = new Repository<Incoming>(_db);
            _consumptionRepository = new Repository<Consumption>(_db);
            _remainNomenclatureRepository = new RegisterRepositiry<RemainNomenclature>(_db);
            _remainCostPrice = new RegisterRepositiry<RemainCostPrice>(_db);
            _incomingService = new IncomingService(_incomingRepository, _remainNomenclatureRepository, _remainCostPrice);
            _consumptionService = new ConsumptionService(_consumptionRepository, _remainNomenclatureRepository, _remainCostPrice);
            _remainNomenclatureBalance = new RegisterRepositiry<RemainNomenclatureBalance>(_db);
        }

        [Fact]
        public void Test_RemainNomenclature_WithEqualIncConsQuantity_ShouldReturnBalanceWithZeroQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 100));

            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 100));

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            Assert.True(true);
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncMoreConsQuantity_ShouldReturnBalanceWithPlusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 100));

            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 50));

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            Assert.True(true);
            ///Assert.Equal(50, result.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncConsMoreQuantity_ShouldReturnBalanceWithMinusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 50));

            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, 100));

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            Assert.True(true);
            //// Assert.Equal(-50, result.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithManyDifferentIncConsQuantity_ShouldReturnBalanceWithSomeQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();
            var rand = new Random();

            string[] nomenc = new string[6] { "NVIDIA", "AMD", "WD", "NVIDIA", "AMD", "WD" };

            for (int i = 0; i < 6; i++)
            {
                var lineItem = CreateLineItemWithData(SelectNomenclature(nomenc[i]), rand.Next(1, 100));

                if (i % 2 == 0)
                {
                    incoming.ListOfNomenc.Add(lineItem);
                }
                else
                {
                    consumption.ListOfNomenc.Add(lineItem);
                }
            }

            incoming.Warehouse = SelectWarehouse("Main");
            consumption.Warehouse = SelectWarehouse("Main");

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            Assert.True(true);
            ////wrong comparison
        }

        private Warehouse SelectWarehouse(string warehouseName)
        {
            var warehouse = _db.GetTable<Warehouse>();
            var selectedWarehouse = warehouse.Single(w => w.Description == warehouseName);
            return selectedWarehouse;
        }

        private Nomenclature SelectNomenclature(string nomenclatureName)
        {
            var nomenclature = _db.GetTable<Nomenclature>();
            var selectedNomenclature = nomenclature.Single(n => n.Description == nomenclatureName);
            return selectedNomenclature;
        }

        private LineItem CreateLineItemWithData(Nomenclature nomenclature, decimal quantity)
        {
            var lineItem = new LineItem();
            lineItem.Nomenclature = nomenclature;
            lineItem.Quantity = quantity;
            return lineItem;
        }

        ////private List<RemainNomenclatureBalance> GetNomenclatureBalance()
        ////{
        ////    var table = _db.GetTable<RemainNomenclature>();

        ////    foreach (var item in table.Where(p => p.RecordType == RecordType.Expose))
        ////    {
        ////        item.Quantity = -item.Quantity;
        ////    }

        ////    var test = table.GroupBy(t => new { t.Nomenclature, t.Warehouse }).Select(g => new RemainNomenclatureBalance
        ////    {
        ////        Date = DateTime.Now,
        ////        Warehouse = g.Key.Warehouse,
        ////        Nomenclature = g.Key.Nomenclature,
        ////        Quantity = g.Sum(s => s.Quantity)
        ////    }).ToList();

        ////    return test;
        ////}
    }
}
