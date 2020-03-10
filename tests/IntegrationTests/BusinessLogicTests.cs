using System;
using System.Collections.Generic;
using System.Linq;
using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class BusinessLogicTests
    {
        private readonly IDb _db;

        public BusinessLogicTests()
        {
            _db = new State();
        }

        public void Test_IncomingWriteToState_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            State state = new State();
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(description);
            DateTime date = DateTime.Now;
            var incoming = new Incoming(date);

            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            incoming.Warehouse = state.Warehouses[0];
            incoming.ListOfNomenc.Add(lineItem);

        }

        public void Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState(string description, decimal price, decimal quantity)
        {
            State state = new State();
            var lineItem = new LineItem();
            var nomenclature = new Nomenclature(description);
            DateTime date = DateTime.Now;
            var consumption = new Consumption(date);

            lineItem.Nomenclature = nomenclature;
            lineItem.Price = price;
            lineItem.Quantity = quantity;
            lineItem.Sum = lineItem.Price * lineItem.Quantity;
            consumption.Warehouse = state.Warehouses[0];
            consumption.ListOfNomenc.Add(lineItem);

        }

        public void Test_SubtractionConsuptionAndAddingIncomingsToState_WithStateData_ShouldCalculateInState()
        {
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("some desc", 50, 100);
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("another desc", 60, 110);
            Test_IncomingWriteToState_WithData_ShouldWriteDataToState("one more desc", 70, 120);

            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("some desc", 50, 100);
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("another desc", 60, 110);
            Test_ConsumptionWriteToState_WithData_ShouldWriteDataToState("one more desc", 70, 120);
            State state = new State();

           var resultInc  = state.Incomings.GroupBy(i => i)

            //  var result = state.Incomings.Concat(state.Consumptions);
        }
    }
}
