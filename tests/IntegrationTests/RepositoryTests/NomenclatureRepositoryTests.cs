using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class NomenclatureRepositoryTests
    {
        [Fact]
        public void TestNomenclatureDbAdd_WithNewNomenclature_ShouldAddTheNomenclatureToDb()
        {

            var repository = new NomenclatureRepository();
            var nomenclature = new Nomenclature("fist desc");
            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            nomenclature.Description = "second desc";
            repository.Update(nomenclature);
            Assert.Equal(nomenclature.Id, nomencFindById.Id);
            Assert.Equal("second desc", nomencFindById.Description);
            repository.Delete(nomenclature.Id);

        }
        [Fact]
        public void TestNomenclatureDbFindById_WithNomenclatureId_ShouldFindTheNomenclatureInDbById()
        {

            var repository = new NomenclatureRepository();
            var nomenclature = new Nomenclature("fist desc");
            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            nomenclature.Description = "second desc";
            repository.Update(nomenclature);
            Assert.Equal(nomenclature.Id, nomencFindById.Id);
            Assert.Equal("second desc", nomencFindById.Description);
            repository.Delete(nomenclature.Id);

        }
        [Fact]
        public void TestNomenclatureDbUbdate_WithNewNomenclature_ShouldUpdateTheNomenclatureToDb()
        {

            var repository = new NomenclatureRepository();
            var nomenclature = new Nomenclature("fist desc");
            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            nomenclature.Description = "second desc";
            repository.Update(nomenclature);
            Assert.Equal(nomenclature.Id, nomencFindById.Id);
            Assert.Equal("second desc", nomencFindById.Description);
            repository.Delete(nomenclature.Id);

        }
        [Fact]
        public void TestNomenclatureDbDelete_WithNomenclature_ShouldDeleteTheNomenclatureFromDb()
        {

            var repository = new NomenclatureRepository();
            var nomenclature = new Nomenclature("fist desc");
            repository.Create(nomenclature);
            var nomencFindById = repository.GetById(nomenclature.Id);
            nomenclature.Description = "second desc";
            repository.Update(nomenclature);
            Assert.Equal(nomenclature.Id, nomencFindById.Id);
            Assert.Equal("second desc", nomencFindById.Description);
            repository.Delete(nomenclature.Id);

        }
    }
}
