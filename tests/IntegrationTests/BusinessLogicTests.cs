using System;
using System.Collections.Generic;
using System.Linq;
using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.ApplicationCore.Services;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class BusinessLogicTests
    {
        private readonly IDb _db;
        private readonly IRepository<Incoming> _incomingRepository;
        private readonly IRepository<Consumption> _consumptionRepository;
        private readonly IRepository<RemainNomenclature> _remainNomenclatureRepository;
        private readonly IncomingService _incomingService;
        private readonly ConsumptionService _consumptionService;


        public BusinessLogicTests()
        {
            _db = new State();
            _db.Initialize();
            _incomingRepository = new Repository<Incoming>(_db);
            _consumptionRepository = new Repository<Consumption>(_db);
            _remainNomenclatureRepository = new Repository<RemainNomenclature>(_db);
            _incomingService = new IncomingService(_incomingRepository, _remainNomenclatureRepository);
            _consumptionService = new ConsumptionService(_consumptionRepository, _remainNomenclatureRepository);
        }

        [Fact]
        public void Test_RemainNomenclature_WithEqualIncConsQuantity_ShouldReturnBalanceWithZeroQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();
            var warehouse = _db.GetTable<Warehouse>();
            var selectedWarehouse = warehouse.Single(w => w.Description == "Main");
            var nomenclature = _db.GetTable<Nomenclature>();
            var selectedNomenclature = nomenclature.Single(n => n.Description == "AMD");
            var lineItem = new LineItem
            {
                Nomenclature = selectedNomenclature,
                Quantity = 100
            };

            incoming.Warehouse = selectedWarehouse;
            consumption.Warehouse = selectedWarehouse;
            incoming.ListOfNomenc.Add(lineItem);
            consumption.ListOfNomenc.Add(lineItem);

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var table = _db.GetTable<RemainNomenclature>();
            foreach (var item in table.Where(p => p.RecordType == RecordType.Expose))
            {
                item.Quantity = -item.Quantity;
            }
            var test = table.GroupBy(t => new { t.Nomenclature, t.Warehouse }).Select(g => new RemainNomenclatureBalance
            {
                Date = DateTime.Now,
                Warehouse = g.Key.Warehouse,
                Nomenclature = g.Key.Nomenclature,
                Quantity = g.Sum(s => s.Quantity)
            }).ToList();

            Assert.Equal(0, test.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncMoreConsQuantity_ShouldReturnBalanceWithPlusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();
            var warehouse = _db.GetTable<Warehouse>();
            var selectedWarehouse = warehouse.Single(w => w.Description == "Main");
            var nomenclature = _db.GetTable<Nomenclature>();
            var selectedNomenclature = nomenclature.Single(n => n.Description == "AMD");
            var lineItemInc = new LineItem();
            var lineItemCon = new LineItem();

            lineItemInc.Nomenclature = selectedNomenclature;
            lineItemInc.Quantity = 100;
            lineItemCon.Nomenclature = selectedNomenclature;
            lineItemCon.Quantity = 200;
            incoming.Warehouse = selectedWarehouse;
            consumption.Warehouse = selectedWarehouse;
            incoming.ListOfNomenc.Add(lineItemInc);
            consumption.ListOfNomenc.Add(lineItemCon);

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var table = _db.GetTable<RemainNomenclature>();
            foreach (var item in table.Where(p => p.RecordType == RecordType.Expose))
            {
                item.Quantity = -item.Quantity;
            }
            var test = table.GroupBy(t => new { t.Nomenclature, t.Warehouse }).Select(g => new RemainNomenclatureBalance
            {
                Date = DateTime.Now,
                Warehouse = g.Key.Warehouse,
                Nomenclature = g.Key.Nomenclature,
                Quantity = g.Sum(s => s.Quantity)
            }).ToList();

            Assert.Equal((lineItemInc.Quantity - lineItemCon.Quantity), test.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncConsMoreQuantity_ShouldReturnBalanceWithMinusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var warehouse = _db.GetTable<Warehouse>();
            var nomenclature = _db.GetTable<Nomenclature>();

            var selectedWarehouse = warehouse.Single(w => w.Description == "Main");
            var selectedNomenclature = nomenclature.Single(n => n.Description == "AMD");

            var lineItemInc = new LineItem();
            var lineItemCon = new LineItem();

            lineItemInc.Nomenclature = selectedNomenclature;
            lineItemInc.Quantity = 100;

            lineItemCon.Nomenclature = selectedNomenclature;
            lineItemCon.Quantity = 60;

            consumption.Warehouse = selectedWarehouse;
            consumption.ListOfNomenc.Add(lineItemCon);

            incoming.Warehouse = selectedWarehouse;
            incoming.ListOfNomenc.Add(lineItemInc);

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var table = _db.GetTable<RemainNomenclature>();
            foreach (var item in table.Where(p => p.RecordType == RecordType.Expose))
            {
                item.Quantity = -item.Quantity;
            }
            var test = table.GroupBy(t => new { t.Nomenclature, t.Warehouse }).Select(g => new RemainNomenclatureBalance
            {
                Date = DateTime.Now,
                Warehouse = g.Key.Warehouse,
                Nomenclature = g.Key.Nomenclature,
                Quantity = g.Sum(s => s.Quantity)
            }).ToList();

            Assert.Equal((lineItemInc.Quantity - lineItemCon.Quantity), test.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithManyDifferentIncConsQuantity_ShouldReturnBalanceWithSomeQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();
            var warehouse = _db.GetTable<Warehouse>();
            var selectedWarehouse = warehouse.Single(w => w.Description == "Main");
            var nomenclature = _db.GetTable<Nomenclature>();
            /////var selectedNomenclature = nomenclature.Single(n => n.Description == "NVIDIA");
            var rand = new Random();
            string[] nomenc = new string[6] { "NVIDIA", "AMD", "WD", "NVIDIA", "AMD", "WD" };
            for (int i = 0; i < 6; i++)
            {
                var lineItem = new LineItem
                {
                    Nomenclature = nomenclature.Single(n => n.Description == nomenc[i]),
                    Quantity = rand.Next(1, 100)
                };
                if (i % 2 == 0)
                {
                    incoming.ListOfNomenc.Add(lineItem);
                }
                else
                {
                    consumption.ListOfNomenc.Add(lineItem);
                }
            }

            incoming.Warehouse = selectedWarehouse;
            consumption.Warehouse = selectedWarehouse;

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var table = _db.GetTable<RemainNomenclature>();
            foreach (var item in table.Where(p => p.RecordType == RecordType.Expose))
            {
                item.Quantity = -item.Quantity;
            }
            var test = table.GroupBy(t => new { t.Nomenclature, t.Warehouse }).Select(g => new RemainNomenclatureBalance
            {
                Date = DateTime.Now,
                Warehouse = g.Key.Warehouse,
                Nomenclature = g.Key.Nomenclature,
                Quantity = g.Sum(s => s.Quantity)
            }).ToList();

            Assert.Equal(0, test.Select(t => t.Quantity).First());
        }
    }
}
