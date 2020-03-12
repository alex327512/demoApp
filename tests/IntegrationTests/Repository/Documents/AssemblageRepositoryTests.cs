using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests.Repository.Documents
{
    public class AssemblageRepositoryTests
    {
        private readonly IDb _db;

        public AssemblageRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestAssemblageDbAdd_WithNewAssemblage_ShouldAddTheAssemblageToDb()
        {
            var repository = new Repository<Assemblage>(_db);
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
            var repository = new Repository<Assemblage>(_db);
            var assemblage = new Assemblage();

            repository.Create(assemblage);
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Equal(assemblage.Id, assemblageFindById.Id);
        }

        [Fact]
        public void TestAssemblageDbUbdate_WithNewAssemblage_ShouldUpdateTheAssemblageToDb()
        {
            var repository = new Repository<Assemblage>(_db);
            var assemblage = new Assemblage();

            repository.Create(assemblage);
            var assemblageFindById = repository.GetById(assemblage.Id);
            Assert.Null(assemblageFindById.Warehouse);
            var warehouse = new Warehouse("warehouse name");
            assemblage.Warehouse = warehouse;
            repository.Update(assemblage);
            Assert.Equal("warehouse name", assemblageFindById.Warehouse.Description);
        }

        [Fact]
        public void TestAssemblageDbDelete_WithAssemblage_ShouldDeleteTheAssemblageFromDb()
        {
            var repository = new Repository<Assemblage>(_db);
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
