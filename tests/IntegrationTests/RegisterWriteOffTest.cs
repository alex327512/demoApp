using System;
using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.ApplicationCore.Services.Documents;
using StudyingProgect.Infrastucture;
using StudyingProgect.Infrastucture.RegistersRepositories.Accumulation;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class RegisterWriteOffTest
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


        public RegisterWriteOffTest()
        {
            _db = new State();
            _db.Initialize();
            _incomingRepository = new Repository<Incoming>(_db);
            _consumptionRepository = new Repository<Consumption>(_db);
            _remainNomenclatureRepository = new RemainNomenclatureRegisterRepository(_db);
            _remainCostPrice = new RemainCostPriceRegisterRepository(_db);
            _incomingService = new IncomingService(_incomingRepository, _remainNomenclatureRepository, _remainCostPrice);
            _consumptionService = new ConsumptionService(_consumptionRepository, _remainNomenclatureRepository, _remainCostPrice, _db);
            _remainNomenclatureBalance = new RemainNomenclatureBalanceRegisterRepository(_db);
            _remainCostPriceBalance = new RemainCostPriceBalanceRegisterRepository(_db);
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

            _consumptionService.Write(consumption);
            _consumptionService.Write(consumption);
            _consumptionService.Write(consumption);
            remainNomenclatureBalance = _db.GetLeftoversRemainNomenclatureBalance("AMD", "Main");
            Assert.Equal(incomingQuantity - consumptionQuantity, costPriceBalance.Select(t => t.Amount).First());
            Assert.Equal(incomingQuantity - consumptionQuantity, remainNomenclatureBalance.Select(t => t.Quantity).First());
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
