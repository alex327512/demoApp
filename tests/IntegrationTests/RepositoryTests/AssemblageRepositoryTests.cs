using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class AssemblageRepositoryTests
    {


        [Fact]
        public void TestAssemblageDbAccess_WittIdOrAssemblage_ShouldEditAssemblageDb()
        {
            var repository = new AssemblageRepository();
            var assemblage = new Assemblage();
            repository.Create(assemblage);
            var item = repository.GetById(assemblage.Id);
            var warehouse = new Warehouse("warehouse name");
            assemblage.Warehouse = warehouse;
            repository.Update(assemblage);

            Assert.Equal(assemblage.Id, item.Id);
            Assert.Equal(warehouse, item.Warehouse);
        }

    }
}