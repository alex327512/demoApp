using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;


namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class IncomingRepositoryTests
    {


        [Fact]
        public void TestIncomingDbAccess_WittIdOrIncoming_ShouldEditIncomingDb()
        {
            var repository = new IncomingRepository();
            var incoming = new Incoming();
            repository.Create(incoming);
            var item = repository.GetById(incoming.Id);
            var warehouse = new Warehouse("warehouse name");
            incoming.Warehouse = warehouse;
            repository.Update(incoming);

            Assert.Equal(incoming.Id, item.Id);
            Assert.Equal(warehouse, item.Warehouse);

        }
    }
}