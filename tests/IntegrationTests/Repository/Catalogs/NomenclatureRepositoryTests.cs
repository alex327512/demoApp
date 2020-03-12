using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests.Repository.Catalogs
{

    public class NomenclatureRepositoryTests
    {
        private readonly IDb _db;

        public NomenclatureRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestNomenclatureDbAdd_WithNewNomenclature_ShouldAddTheNomenclatureToDb()
        {
            var repository = new Repository<Nomenclature>(_db);
            var nomenclature = new Nomenclature("fist desc");
            var nomencFindById = repository.GetById(nomenclature.Id);

            Assert.Null(nomencFindById);
            repository.Create(nomenclature);
            nomencFindById = repository.GetById(nomenclature.Id);
            Assert.NotNull(nomencFindById);
        }

        [Fact]
        public void TestNomenclatureDbFindById_WithNomenclatureId_ShouldFindTheNomenclatureInDbById()
        {
            var repository = new Repository<Nomenclature>(_db);
            var nomenclature = new Nomenclature("fist desc");

            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            Assert.Equal(nomenclature.Id, nomencFindById.Id);
        }

        [Fact]
        public void TestNomenclatureDbUbdate_WithNewNomenclature_ShouldUpdateTheNomenclatureToDb()
        {
            var repository = new Repository<Nomenclature>(_db);
            var nomenclature = new Nomenclature("fist desc");

            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            Assert.Equal("fist desc", nomencFindById.Description);
            nomenclature.Description = "second desc";
            repository.Update(nomenclature);
            Assert.Equal("second desc", nomencFindById.Description);
        }

        [Fact]
        public void TestNomenclatureDbDelete_WithNomenclature_ShouldDeleteTheNomenclatureFromDb()
        {
            var repository = new Repository<Nomenclature>(_db);
            var nomenclature = new Nomenclature("fist desc");

            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            Assert.NotNull(nomencFindById);
            repository.Delete(nomenclature.Id);
            nomencFindById = repository.GetById(nomenclature.Id);
            Assert.Null(nomencFindById);
        }
    }
}
