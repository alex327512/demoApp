using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class RemainNomenclatureRepositoryTests
    {
        private readonly IDb _db;

        public RemainNomenclatureRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestRemainNomenclatureDbAdd_WithNewRemainNomenclature_ShouldAddTheRemainNomenclatureToDb()
        {
            var repository = new Repository<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Null(remainNomenclatureById);
            repository.Create(remainNomenclature);
            remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.NotNull(remainNomenclatureById);
        }

        [Fact]
        public void TestRemainNomenclatureDbFindById_WithRemainNomenclatureId_ShouldFindTheRemainNomenclatureInDbById()
        {
            var repository = new Repository<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Equal(remainNomenclature.Id, remainNomenclatureById.Id);
        }

        [Fact]
        public void TestRemainNomenclatureDbUbdate_WithNewRemainNomenclature_ShouldUpdateTheRemainNomenclatureToDb()
        {
            var repository = new Repository<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Null(remainNomenclatureById.Warehouse);
            var warehouse = new Warehouse("warehouse name");
            remainNomenclature.Warehouse = warehouse;
            repository.Update(remainNomenclature);
            Assert.Equal("warehouse name", remainNomenclatureById.Warehouse.Description);
        }

        [Fact]
        public void TestRemainNomenclatureDbDelete_WithRemainNomenclature_ShouldDeleteTheRemainNomenclatureFromDb()
        {
            var repository = new Repository<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.NotNull(remainNomenclatureById);
            repository.Delete(remainNomenclature.Id);
            remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Null(remainNomenclatureById);
        }
    }
}
