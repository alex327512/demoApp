using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class WarehouseRepositoryTests
    {
        [Fact]
        public void TestWarehouseDbAdd_WithNewWarehouse_ShouldAddTheWarehouseToDb()
        {
            var repository = new WarehouseRepository();
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
            var repository = new WarehouseRepository();
            var warehouse = new Warehouse("first desc");
            repository.Create(warehouse);
            var warehouseFindById = repository.GetById(warehouse.Id);
            Assert.Equal(warehouse.Id, warehouseFindById.Id);
        }

        [Fact]
        public void TestWarehouseDbUbdate_WithNewWarehouse_ShouldUpdateTheWarehouseToDb()
        {
            var repository = new WarehouseRepository();
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
            var repository = new WarehouseRepository();
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
