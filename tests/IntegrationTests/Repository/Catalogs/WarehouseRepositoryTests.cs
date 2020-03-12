using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests.Repository.Catalogs
{
    public class WarehouseRepositoryTests
    {
        private readonly IDb _db;

        public WarehouseRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestWarehouseDbAdd_WithNewWarehouse_ShouldAddTheWarehouseToDb()
        {
            var repository = new Repository<Warehouse>(_db);
            var warehouse = new Warehouse("first desc");
            var warehouseFindById = repository.GetById(warehouse.Id);

            Assert.Null(warehouseFindById);
            repository.Create(warehouse);
            warehouseFindById = repository.GetById(warehouse.Id);
            Assert.NotNull(warehouseFindById);
        }

        [Fact]
        public void TestWarehouseDbFindById_WithWarehouseId_ShouldFindTheWarehouseInDbById()
        {
            var repository = new Repository<Warehouse>(_db);
            var warehouse = new Warehouse("first desc");

            repository.Create(warehouse);
            var warehouseFindById = repository.GetById(warehouse.Id);
            Assert.Equal(warehouse.Id, warehouseFindById.Id);
        }

        [Fact]
        public void TestWarehouseDbUbdate_WithNewWarehouse_ShouldUpdateTheWarehouseToDb()
        {
            var repository = new Repository<Warehouse>(_db);
            var warehouse = new Warehouse("first desc");

            repository.Create(warehouse);
            var warehouseFindById = repository.GetById(warehouse.Id);
            Assert.Equal("first desc", warehouseFindById.Description);
            warehouse.Description = "second desc";
            repository.Update(warehouse);
            Assert.Equal("second desc", warehouseFindById.Description);
        }

        [Fact]
        public void TestWarehouseDbDelete_WithWarehouse_ShouldDeleteTheWarehouseFromDb()
        {
            var repository = new Repository<Warehouse>(_db);
            var warehouse = new Warehouse("first desc");

            repository.Create(warehouse);
            var warehouseFindById = repository.GetById(warehouse.Id);
            Assert.NotNull(warehouseFindById);
            repository.Delete(warehouse.Id);
            warehouseFindById = repository.GetById(warehouse.Id);
            Assert.Null(warehouseFindById);
        }
    }
}
