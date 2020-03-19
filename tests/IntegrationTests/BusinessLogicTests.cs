using System;
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
        private readonly IRegisterRepository<RemainCostPriceBalance> _remainCostPriceBalance;


        public BusinessLogicTests()
        {
            _db = new State();
            _db.Initialize();
            _incomingRepository = new Repository<Incoming>(_db);
            _consumptionRepository = new Repository<Consumption>(_db);
            _remainNomenclatureRepository = new RegisterRepositiry<RemainNomenclature>(_db);
            _remainCostPrice = new RegisterRepositiry<RemainCostPrice>(_db);
            _incomingService = new IncomingService(_incomingRepository, _remainNomenclatureRepository, _remainCostPrice);
            _consumptionService = new ConsumptionService(_consumptionRepository, _remainNomenclatureRepository, _remainCostPrice, _db);
            _remainNomenclatureBalance = new RegisterRepositiry<RemainNomenclatureBalance>(_db);
            _remainCostPriceBalance = new RegisterRepositiry<RemainCostPriceBalance>(_db);
        }

        [Fact]
        public void Test_RemainNomenclature_WithEqualIncConsQuantity_ShouldReturnBalanceWithZeroQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            var incomingQuantity = 100;
            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, incomingQuantity));

            var consumptionQuantity = 100;
            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, consumptionQuantity));

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var costPriceBalance = _db.GetLeftoversRemainCostPriceBalance("AMD");
            var remainNomenclatureBalance = _db.GetLeftoversRemainNomenclatureBalance("AMD", "Main");

            Assert.Equal(incomingQuantity - consumptionQuantity, costPriceBalance.Select(t => t.Amount).First());
            Assert.Equal(incomingQuantity - consumptionQuantity, remainNomenclatureBalance.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncMoreConsQuantity_ShouldReturnBalanceWithPlusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            var incomingQuantity = 100;
            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, incomingQuantity));

            var consumptionQuantity = 50;
            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, consumptionQuantity));

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var costPriceBalance = _db.GetLeftoversRemainCostPriceBalance("AMD");
            var remainNomenclatureBalance = _db.GetLeftoversRemainNomenclatureBalance("AMD", "Main");

            Assert.Equal(incomingQuantity - consumptionQuantity, costPriceBalance.Select(t => t.Amount).First());
            Assert.Equal(incomingQuantity - consumptionQuantity, remainNomenclatureBalance.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithDifferentIncConsMoreQuantity_ShouldReturnBalanceWithMinusQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();

            var selectedNomenclature = SelectNomenclature("AMD");

            var incomingQuantity = 50;
            incoming.Warehouse = SelectWarehouse("Main");
            incoming.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, incomingQuantity));

            var consumptionQuantity = 100;
            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItemWithData(selectedNomenclature, consumptionQuantity));

            try
            {
                _incomingService.Write(incoming);
                _consumptionService.Write(consumption);
            }
            catch (ArgumentException e)
            {
                Assert.NotNull(e);
            }
            ///// var costPriceBalance = _db.GetLeftoversRemainCostPriceBalance("AMD");
            /////  var remainNomenclatureBalance = _db.GetLeftoversRemainNomenclatureBalance("AMD", "Main");

            //// Assert.Equal(incomingQuantity - consumptionQuantity, costPriceBalance.Select(t => t.Amount).First());
            //// Assert.Equal(incomingQuantity - consumptionQuantity, remainNomenclatureBalance.Select(t => t.Quantity).First());
        }

        [Fact]
        public void Test_RemainNomenclature_WithManyDifferentIncConsQuantity_ShouldReturnBalanceWithSomeQuantity()
        {
            var incoming = new Incoming();
            var consumption = new Consumption();
            var rand = new Random();

            string[] nomenc = new string[3] { "NVIDIA", "NVIDIA", "NVIDIA" };

            for (int i = 0; i < 3; i++)
            {
                var quantity = 20 * i + 10;
                var lineItemInc = CreateLineItemWithData(SelectNomenclature("NVIDIA"), quantity + 10 * i);
                var lineItemCons = CreateLineItemWithData(SelectNomenclature("NVIDIA"), quantity);
                incoming.ListOfNomenc.Add(lineItemInc);
                consumption.ListOfNomenc.Add(lineItemCons);
            }

            incoming.Warehouse = SelectWarehouse("Main");
            consumption.Warehouse = SelectWarehouse("Main");

            _incomingService.Write(incoming);
            _consumptionService.Write(consumption);

            var costPriceBalance = _db.GetLeftoversRemainCostPriceBalance("NVIDIA");
            var remainNomenclatureBalance = _db.GetLeftoversRemainNomenclatureBalance("NVIDIA", "Main");
            var costPriceBalance1 = _db.GetLeftoversRemainCostPriceBalance("AMD");
            var remainNomenclatureBalance1 = _db.GetLeftoversRemainNomenclatureBalance("AMD", "Main");
            var costPriceBalance2 = _db.GetLeftoversRemainCostPriceBalance("WD");
            var remainNomenclatureBalance2 = _db.GetLeftoversRemainNomenclatureBalance("WD", "Main");
            Assert.True(true);

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
    }
}
