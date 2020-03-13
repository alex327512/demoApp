using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests.Repository.Registers
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
            var repository = new RegisterRepositiry<RemainNomenclature>(_db);
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
            var repository = new RegisterRepositiry<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();

            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Equal(remainNomenclature.Id, remainNomenclatureById.Id);
        }

        [Fact]
        public void TestRemainNomenclatureDbUbdate_WithNewRemainNomenclature_ShouldUpdateTheRemainNomenclatureToDb()
        {
            var repository = new RegisterRepositiry<RemainNomenclature>(_db);
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
            var repository = new RegisterRepositiry<RemainNomenclature>(_db);
            var remainNomenclature = new RemainNomenclature();

            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.NotNull(remainNomenclatureById);
            repository.Delete(remainNomenclature);
            remainNomenclatureById = repository.GetById(remainNomenclature.Id);
            Assert.Null(remainNomenclatureById);
        }
    }
}
