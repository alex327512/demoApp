using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class ConsumptionRepositoryTests
    {


        [Fact]
        public void TestConsumptionDbAccess_WittIdOrConsumption_ShouldEditConsumptionDb()
        {
            var repository = new ConsumptionRepository();
            var consumption = new Consumption();
            repository.Create(consumption);
            var item = repository.GetById(consumption.Id);
            var warehouse = new Warehouse("warehouse name");
            consumption.Warehouse = warehouse;
            repository.Update(consumption);

            Assert.Equal(consumption.Id, item.Id);
            Assert.Equal(warehouse, item.Warehouse);

        }

    }
}