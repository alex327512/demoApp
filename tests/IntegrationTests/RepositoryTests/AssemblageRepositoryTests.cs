using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{
    public class AssemblageRepositoryTests
    {

        [Fact]
        public void TestAssemblageDbAdd_WithNewAssemblage_ShouldAddTheAssemblageToDb()
        {
            var repository = new AssemblageRepository();
            var assemblage = new Assemblage();
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Null(assemblageFindById);
            repository.Create(assemblage);
            assemblageFindById = repository.GetById(assemblage.Id);
            Assert.NotNull(assemblageFindById);
        }
        [Fact]
        public void TestAssemblageDbFindById_WithAssemblageId_ShouldFindTheAssemblageInDbById()
        {
            var repository = new AssemblageRepository();
            var assemblage = new Assemblage();
            repository.Create(assemblage);
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Equal(assemblage.Id, assemblageFindById.Id);
        }
        [Fact]
        public void TestAssemblageDbUbdate_WithNewAssemblage_ShouldUpdateTheAssemblageToDb()
        {

            var repository = new AssemblageRepository();
            var assemblage = new Assemblage();
            repository.Create(assemblage);
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Null(assemblageFindById.Warehouse.Description);
            var warehouse = new Warehouse("warehouse name");
            assemblage.Warehouse = warehouse;
            repository.Update(assemblage);
            Assert.Equal("warehouse name", assemblageFindById.Warehouse.Description);
        }
        [Fact]
        public void TestAssemblageDbDelete_WithAssemblage_ShouldDeleteTheAssemblageFromDb()
        {
            var repository = new AssemblageRepository();
            var assemblage = new Assemblage();
            repository.Create(assemblage);
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.NotNull(assemblageFindById);
            repository.Delete(assemblage.Id);
            assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Null(assemblageFindById);
        }
    }
}
