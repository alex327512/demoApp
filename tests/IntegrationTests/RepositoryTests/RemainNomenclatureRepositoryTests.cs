using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class RemainNomenclatureRepositoryTests
    {
        [Fact]
        public void TestRemainNomenclatureDbAdd_WithNewRemainNomenclature_ShouldAddTheRemainNomenclatureToDb()
        {
            var repository = new RemainNomenclatureRepository();
            var remainNomenclature = new RemainNomenclature();
            var remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.Null(remainNomenclatureById);
            repository.Create(remainNomenclature);
            remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.NotNull(remainNomenclatureById);
        }

        [Fact]
        public void TestRemainNomenclatureDbFindById_WithRemainNomenclatureId_ShouldFindTheRemainNomenclatureInDbById()
        {
            var repository = new RemainNomenclatureRepository();
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.Equal(remainNomenclature.DocumentId, remainNomenclatureById.DocumentId);
        }

        [Fact]
        public void TestRemainNomenclatureDbUbdate_WithNewRemainNomenclature_ShouldUpdateTheRemainNomenclatureToDb()
        {
            var repository = new RemainNomenclatureRepository();
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.Null(remainNomenclatureById.Warehouse);
            var warehouse = new Warehouse("warehouse name");
            remainNomenclature.Warehouse = warehouse;
            repository.Update(remainNomenclature);
            Assert.Equal("warehouse name", remainNomenclatureById.Warehouse.Description);
        }

        [Fact]
        public void TestRemainNomenclatureDbDelete_WithRemainNomenclature_ShouldDeleteTheRemainNomenclatureFromDb()
        {
            var repository = new RemainNomenclatureRepository();
            var remainNomenclature = new RemainNomenclature();
            repository.Create(remainNomenclature);
            var remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.NotNull(remainNomenclatureById);
            repository.Delete(remainNomenclature.DocumentId);
            remainNomenclatureById = repository.GetById(remainNomenclature.DocumentId);
            Assert.Null(remainNomenclatureById);
        }
    }
}
