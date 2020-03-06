using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Test_Nomenclature_WithEmptyData_ShouldContainData()
        {
            string description = "Some description";
            var nomeclature = new Nomenclature(description);

            Assert.NotEqual(Guid.Empty, nomeclature.Id);
            Assert.NotEmpty(nomeclature.Description);
            Assert.Equal(description, nomeclature.Description);
        }

        [Fact]
        public void Test_Warehouse_WithEmptyData_ShouldContainData()
        {
            string description = "Some description";
            var warhouse = new Warehouse(description);

            Assert.NotEqual(Guid.Empty, warhouse.Id);
            Assert.NotEmpty(warhouse.Description);
            Assert.Equal(description, warhouse.Description);
        }

        [Fact]
        public void Test_Assemblage_WithEmptyData_ShouldContainData()
        {
            string description = "Some description";
            DateTime date = DateTime.Now;
            var assemblage = new Assemblage(date);
            var warehouse = new Warehouse(description);
            assemblage.Warehouse = warehouse;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(description);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = 100;
            lineItem.Quantity = 100;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            assemblage.ListOfNomenc.Add(lineItem);

            Assert.NotEqual(Guid.Empty, assemblage.Id);
            Assert.Equal(date, assemblage.Date);
            Assert.Equal(description, assemblage.Warehouse.Description);
            Assert.Collection(assemblage.ListOfNomenc, item => item.Nomenclature.Description.Equals(description));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Price.Equals(lineItem.Price));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Quantity.Equals(lineItem.Quantity));
            Assert.Collection(assemblage.ListOfNomenc, item => item.Sum.Equals(lineItem.Sum));
        }

        [Fact]
        public void Test_Consumption_WithEmptyData_ShouldContainData()
        {
            string description = "Some description";
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            var warehouse = new Warehouse(description);
            consumption.Warehouse = warehouse;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(description);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = 100;
            lineItem.Quantity = 100;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            consumption.ListOfNomenc.Add(lineItem);

            Assert.NotEqual(Guid.Empty, consumption.Id);
            Assert.Equal(date, consumption.Date);
            Assert.Equal(description, consumption.Warehouse.Description);
            Assert.Collection(consumption.ListOfNomenc, item => item.Nomenclature.Description.Equals(description));
            Assert.Collection(consumption.ListOfNomenc, item => item.Price.Equals(lineItem.Price));
            Assert.Collection(consumption.ListOfNomenc, item => item.Quantity.Equals(lineItem.Quantity));
            Assert.Collection(consumption.ListOfNomenc, item => item.Sum.Equals(lineItem.Sum));
        }

        [Theory]
        [InlineData("some desc", 50, 100)]
        [InlineData("another desc", 60, 110)]
        [InlineData("one more desc", 70, 120)]
        public void Test_ConsumptionWriteTo_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            string text = description;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(text);
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            var warehouse = new Warehouse(text);
            consumption.Warehouse = warehouse;
            consumption.ListOfNomenc.Add(lineItem);

            foreach (var item in consumption.ListOfNomenc)
            {
                var remain = new RemainNomenclature();
                remain.Nomenclature = item.Nomenclature;
                remain.Warehouse = consumption.Warehouse;
                remain.Date = consumption.Date;
                remain.Quantity = item.Quantity;
                remain.RecordType = RecordType.Expose;
                State.RemainNomenclature.Add(remain);
            }

            Assert.NotEqual(Guid.Empty, consumption.Id);
            Assert.Equal(date, consumption.Date);
            Assert.Equal(description, consumption.Warehouse.Description);
            Assert.Collection(State.RemainNomenclature, item => item.Warehouse.Description.Equals(text));
            Assert.Collection(State.RemainNomenclature, item => item.Quantity.Equals(lineItem.Quantity));
            Assert.Collection(State.RemainNomenclature, item => item.Date.Equals(date));
            Assert.Collection(State.RemainNomenclature, item => item.RecordType.Equals(RecordType.Expose));
            Assert.Collection(State.RemainNomenclature, item => item.Nomenclature.Equals(nomenclature));

            State.RemainNomenclature.Clear();
        }

        [Theory]
        [InlineData("some desc", 50, 100)]
        [InlineData("another desc", 60, 110)]
        [InlineData("one more desc", 70, 120)]
        public void Test_IncomingWriteTo_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            string text = description;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(text);
            DateTime date = DateTime.Now;
            var incoming = new Incoming(date);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            var warehouse = new Warehouse(text);
            incoming.Warehouse = warehouse;
            incoming.ListOfNomenc.Add(lineItem);

            foreach (var item in incoming.ListOfNomenc)
            {
                var remain = new RemainNomenclature();
                remain.Nomenclature = item.Nomenclature;
                remain.Warehouse = incoming.Warehouse;
                remain.Date = incoming.Date;
                remain.Quantity = item.Quantity;
                remain.RecordType = RecordType.Receipt;
                State.RemainNomenclature.Add(remain);
            }

            Assert.NotEqual(Guid.Empty, incoming.Id);
            Assert.Equal(date, incoming.Date);
            Assert.Equal(description, incoming.Warehouse.Description);
            Assert.Collection(State.RemainNomenclature, item => item.Warehouse.Description.Equals(text));
            Assert.Collection(State.RemainNomenclature, item => item.Quantity.Equals(lineItem.Quantity));
            Assert.Collection(State.RemainNomenclature, item => item.Date.Equals(date));
            Assert.Collection(State.RemainNomenclature, item => item.RecordType.Equals(RecordType.Receipt));
            Assert.Collection(State.RemainNomenclature, item => item.Nomenclature.Equals(nomenclature));

            State.RemainNomenclature.Clear();
        }


        [Theory]
        [InlineData("some desc", 50, 100)]
        [InlineData("another desc", 60, 110)]
        [InlineData("one more desc", 70, 120)]
        public void Test_IncomingWriteToState_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            string text = description;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(text);
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            var warehouse = new Warehouse(text);
            consumption.Warehouse = warehouse;
            consumption.ListOfNomenc.Add(lineItem);

            foreach (var item in consumption.ListOfNomenc)
            {
                var remain = new RemainNomenclature();
                remain.Nomenclature = item.Nomenclature;
                remain.Warehouse = consumption.Warehouse;
                remain.Date = consumption.Date;
                remain.Quantity = item.Quantity;
                remain.RecordType = RecordType.Receipt;
                State.RemainNomenclature.Add(remain);
            }

            Assert.True(true);

        }

        [Theory]
        [InlineData("some desc", 50, 100)]
        [InlineData("another desc", 60, 110)]
        [InlineData("one more desc", 70, 120)]
        public void Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            string text = description;
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(text);
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);
            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            var warehouse = new Warehouse(text);
            consumption.Warehouse = warehouse;
            consumption.ListOfNomenc.Add(lineItem);

            foreach (var item in consumption.ListOfNomenc)
            {

                var remain = new RemainNomenclature();
                remain.Nomenclature = item.Nomenclature;
                remain.Warehouse = consumption.Warehouse;
                remain.Date = consumption.Date;
                remain.Quantity = item.Quantity;
                remain.RecordType = RecordType.Expose;
                State.RemainNomenclature.Add(remain);
            }

            Assert.True(true);
        }


        [Fact]

        public void Test_SubtractionConsuptionAndAddingIncomingsToState_WithStateData_ShouldCalculateInState()
        {
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("some desc", 50, 100);
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("another desc", 60, 110);
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("one more desc", 70, 120);

            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("some desc", 50, 100);
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("another desc", 60, 110);
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("one more desc", 70, 120);
            var result = new List<RemainNomenclature>();

            foreach (var item in State.RemainNomenclature)
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
    }
}
