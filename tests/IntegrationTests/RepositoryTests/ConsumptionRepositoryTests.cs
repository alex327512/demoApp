using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class ConsumptionRepositoryTests
    {
        private readonly IDb _db;

        public ConsumptionRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestConsumptionDbAdd_WithNewConsumption_ShouldAddTheConsumptionToDb()
        {
            var repository = new Repository<Consumption>(_db);
            var consumption = new Consumption();
            var consumptionFindById = repository.GetById(consumption.Id);
            Assert.Null(consumptionFindById);
            repository.Create(consumption);
            consumptionFindById = repository.GetById(consumption.Id);
            Assert.NotNull(consumptionFindById);
        }

        [Fact]
        public void TestConsumptionDbFindById_WithConsumptionId_ShouldFindTheConsumptionInDbById()
        {
            var repository = new Repository<Consumption>(_db);
            var consumption = new Consumption();
            repository.Create(consumption);
            var consumptionFindById = repository.GetById(consumption.Id);
            Assert.Equal(consumption.Id, consumptionFindById.Id);
        }

        [Fact]
        public void TestConsumptionDbUbdate_WithNewConsumption_ShouldUpdateTheConsumptionToDb()
        {
            var repository = new Repository<Consumption>(_db);
            var consumption = new Consumption();
            repository.Create(consumption);
            var consumptionFindById = repository.GetById(consumption.Id);
            Assert.Null(consumptionFindById.Warehouse);
            var warehouse = new Warehouse("warehouse name");
            consumption.Warehouse = warehouse;
            repository.Update(consumption);
            Assert.Equal("warehouse name", consumptionFindById.Warehouse.Description);
        }

        [Fact]
        public void TestConsumptionDbDelete_WithConsumption_ShouldDeleteTheConsumptionFromDb()
        {
            var repository = new Repository<Consumption>(_db);
            var consumption = new Consumption();
            repository.Create(consumption);
            var consumptionFindById = repository.GetById(consumption.Id);
            Assert.NotNull(consumptionFindById);
            repository.Delete(consumption.Id);
            consumptionFindById = repository.GetById(consumption.Id);
            Assert.Null(consumptionFindById);
        }
    }
}
