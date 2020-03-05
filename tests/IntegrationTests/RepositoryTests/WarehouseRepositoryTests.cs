using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class WarehouseRepositoryTests
    {


        [Fact]
        public void TestWarehouseDbAccess_WittIdOrWarehouse_ShouldEditWarehouseDb()
        {
            var repository = new WarehouseRepository();
            var warehouse = new Warehouse("first desc");
            repository.Create(warehouse);
            var item = repository.GetById(warehouse.Id);
            warehouse.Description = "second desc";
            repository.Update(warehouse);
            Assert.Equal(warehouse.Id, item.Id);
            Assert.Equal("second desc", item.Description);
        }
    }
}