using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class RemainNomenclatureRepositoryTests
    {


        [Fact]
        public void TestRemainNomenclatureDbAccess_WittIdOrRemainNomenclature_ShouldEditRemainNomenclatureDb()
        {
            var repository = new RemainNomenclatureRepository();
            var remainNomenclature = new RemainNomenclature();


            var warehouse = new Warehouse("warehouse name");
            remainNomenclature.Warehouse = warehouse;


            repository.Create(remainNomenclature);
            var item = repository.GetById(remainNomenclature.DocumentId);
            repository.Update(remainNomenclature);
            //Assert.Collection(repository, el => el.) ;

            Assert.Equal(remainNomenclature.DocumentId, item.DocumentId);
            Assert.Equal(warehouse, item.Warehouse);

            repository.Delete(item.DocumentId);

            //Assert.Equal(repository.GetById(item.DocumentId), item.DocumentId);
        }
    }

}