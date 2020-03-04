using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class IntegrationTests
    {
        [Fact]
        public void Test1()
        {
            var repository = new NomenclatureRepository();
            var nomenclatore = new Nomenclature("Test");
            repository.Create(nomenclatore);
            var item = repository.GetById(nomenclatore.Id);
            Assert.Equal(nomenclatore.Id, item.Id);
        }
    }
}
