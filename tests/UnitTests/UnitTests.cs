using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace UnitTests
{
    public class UnitTests
    {
        private readonly IDb _db;
        public UnitTests()
        {
            _db = new State();
            _db.Initialize();
        }
        [Fact]
        public void Test_Nomenclature_WithEmptyData_ShouldContainData()
        {
            string description = "AMD";
            var nomeclature = SelectNomenclature(description);

            Assert.NotEqual(Guid.Empty, nomeclature.Id);
            Assert.NotEmpty(nomeclature.Description);
            Assert.Equal(description, nomeclature.Description);
        }

        [Fact]
        public void Test_Warehouse_WithEmptyData_ShouldContainData()
        {
            string description = "Main";
            var warhouse = SelectWarehouse(description);

            Assert.NotEqual(Guid.Empty, warhouse.Id);
            Assert.NotEmpty(warhouse.Description);
            Assert.Equal(description, warhouse.Description);
        }

        [Fact]
        public void Test_Assemblage_WithEmptyData_ShouldContainData()
        {
            DateTime date = DateTime.Now;
            var assemblage = new Assemblage(date);
            assemblage.Warehouse = SelectWarehouse("Main");
            assemblage.ListOfNomenc.Add(CreateLineItem(SelectNomenclature("AMD"), 100, 100));

            Assert.NotEqual(Guid.Empty, assemblage.Id);
            Assert.Equal(date, assemblage.Date);
            Assert.Equal("Main", assemblage.Warehouse.Description);
            Assert.Collection(assemblage.ListOfNomenc, item => item.Nomenclature.Description.Equals("AMD"));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Price.Equals(100));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Quantity.Equals(100));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Sum.Equals(100*100));
        }

        [Fact]
        public void Test_Consumption_WithEmptyData_ShouldContainData()
        {
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            consumption.Warehouse = SelectWarehouse("Main");
            consumption.ListOfNomenc.Add(CreateLineItem(SelectNomenclature("AMD"), 100, 100));

            Assert.NotEqual(Guid.Empty, consumption.Id);
            Assert.Equal(date, consumption.Date);
            Assert.Equal("Main", consumption.Warehouse.Description);
            Assert.Collection(consumption.ListOfNomenc, item => item.Nomenclature.Description.Equals("AMD"));
            Assert.Collection(consumption.ListOfNomenc, item => item.Price.Equals(100));
            Assert.Collection(consumption.ListOfNomenc, item => item.Quantity.Equals(100));
            Assert.Collection(consumption.ListOfNomenc, item => item.Sum.Equals(100*100));
        }

        [Theory]
        [InlineData("AMD", 50, 100, "Main")]
        [InlineData("WD", 60, 110, "Main")]
        [InlineData("NVIDIA", 70, 120, "Main")]
        public void Test_ConsumptionWriteTo_WithData_ShouldWriteDataToState(string nomenclatureDesc, decimal price, decimal quantity, string warehouseName)
        {
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            consumption.Warehouse = SelectWarehouse(warehouseName);
            consumption.ListOfNomenc.Add(CreateLineItem(SelectNomenclature(nomenclatureDesc), price, quantity));

            foreach (var item in consumption.ListOfNomenc)
            {
                AddRemainNomenclatureToDbFromConsumption(item, consumption);
            }

            Assert.NotEqual(Guid.Empty, consumption.Id);
            Assert.Equal(date, consumption.Date);
            Assert.Equal(warehouseName, consumption.Warehouse.Description);
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Warehouse.Description.Equals(warehouseName));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Quantity.Equals(quantity));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Date.Equals(date));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.RecordType.Equals(RecordType.Expose));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Nomenclature.Equals(SelectNomenclature(nomenclatureDesc)));

            _db.GetTable<RemainNomenclature>().Clear();
        }

        [Theory]
        [InlineData("AMD", 50, 100, "Main")]
        [InlineData("WD", 60, 110, "Main")]
        [InlineData("NVIDIA", 70, 120, "Main")]
        public void Test_IncomingWriteTo_WithData_ShouldWriteDataToState(string nomenclatureDesc, decimal price, decimal quantity, string warehouseName)
        {
            DateTime date = DateTime.Now;
            var incoming = new Incoming(date);
            incoming.Warehouse = SelectWarehouse(warehouseName);
            incoming.ListOfNomenc.Add(CreateLineItem(SelectNomenclature(nomenclatureDesc), price, quantity));

            foreach (var item in incoming.ListOfNomenc)
            {
                AddRemainNomenclatureToDbFromIncoming(item, incoming);
            }

            Assert.NotEqual(Guid.Empty, incoming.Id);
            Assert.Equal(date, incoming.Date);
            Assert.Equal(warehouseName, incoming.Warehouse.Description);
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Warehouse.Description.Equals(warehouseName));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Quantity.Equals(quantity));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Date.Equals(date));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.RecordType.Equals(RecordType.Receipt));
            Assert.Collection(_db.GetTable<RemainNomenclature>(), item => item.Nomenclature.Equals(SelectNomenclature(nomenclatureDesc)));

            _db.GetTable<RemainNomenclature>().Clear();
        }

        [Theory]
        [InlineData("AMD", 50, 100, "Main")]
        [InlineData("WD", 60, 110, "Main")]
        [InlineData("NVIDIA", 70, 120, "Main")]
        public void Test_IncomingWriteToState_WithData_ShouldWriteDataToState(string nomenclatureDesc, decimal price, decimal quantity, string warehouseName)
        {
            DateTime date = DateTime.Now;
            var incoming = new Incoming(date);
            incoming.Warehouse = SelectWarehouse(warehouseName);
            incoming.ListOfNomenc.Add(CreateLineItem(SelectNomenclature(nomenclatureDesc), price, quantity));

            foreach (var item in incoming.ListOfNomenc)
            {
                AddRemainNomenclatureToDbFromIncoming(item, incoming);
            }

            Assert.True(true);
        }

        [Theory]
        [InlineData("AMD", 50, 100, "Main")]
        [InlineData("WD", 60, 110, "Main")]
        [InlineData("NVIDIA", 70, 120, "Main")]
        public void Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState(string nomenclatureDesc, decimal price, decimal quantity, string warehouseName)
        {
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            consumption.Warehouse = SelectWarehouse(warehouseName);
            consumption.ListOfNomenc.Add(CreateLineItem(SelectNomenclature(nomenclatureDesc), price, quantity));

            foreach (var item in consumption.ListOfNomenc)
            {
                AddRemainNomenclatureToDbFromConsumption(item, consumption);
            }

            Assert.True(true);
        }

        [Fact]
        public void Test_SubtractionConsuptionAndAddingIncomingsToState_WithStateData_ShouldCalculateInState()
        {
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("AMD", 50, 100, "Main");
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("WD", 60, 110, "Main");
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("NVIDIA", 70, 120, "Main");

            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("AMD", 50, 100, "Main");
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("WD", 60, 110, "Main");
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("NVIDIA", 70, 120, "Main");
            var result = new List<RemainNomenclature>();

            foreach (var item in _db.GetTable<RemainNomenclature>())
            {
                if (result.Count != 0)
                {
                    foreach (var resultEl in result)
                    {
                        if (item.Nomenclature.Description == resultEl.Nomenclature.Description)
                        {
                            if (item.RecordType == RecordType.Expose)
                            {
                                resultEl.Quantity -= item.Quantity;
                            }
                            else
                            {
                                resultEl.Quantity += item.Quantity;
                            }
                        }
                        else
                        {
                            if (item.RecordType == RecordType.Expose)
                            {
                                item.Quantity = -item.Quantity;
                            }
                            result.Add(item);
                        }

                    }
                }
                else
                {
                    if (item.RecordType == RecordType.Expose)
                    {
                        item.Quantity = -item.Quantity;
                    }
                    result.Add(item);
                }

            }
            Assert.Equal(3, result.Count);
        }
        private LineItem CreateLineItem(Nomenclature nomenclature, decimal price, decimal quantity)
        {
            var lineItem = new LineItem();

            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;

            return lineItem;
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

        private void AddRemainNomenclatureToDbFromConsumption(LineItem lineItem, Consumption consumption)
        {
            var remain = new RemainNomenclature();
            remain.Nomenclature = lineItem.Nomenclature;
            remain.Warehouse = consumption.Warehouse;
            remain.Date = consumption.Date;
            remain.Quantity = lineItem.Quantity;
            remain.RecordType = RecordType.Expose;
            _db.GetTable<RemainNomenclature>().Add(remain);
        }
        private void AddRemainNomenclatureToDbFromIncoming(LineItem lineItem, Incoming incoming)
        {
            var remain = new RemainNomenclature();
            remain.Nomenclature = lineItem.Nomenclature;
            remain.Warehouse = incoming.Warehouse;
            remain.Date = incoming.Date;
            remain.Quantity = lineItem.Quantity;
            remain.RecordType = RecordType.Expose;
            _db.GetTable<RemainNomenclature>().Add(remain);
        }
    }
}
