using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;


namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class IncomingRepositoryTests
    {

        [Fact]
        public void TestIncomingDbAdd_WithNewIncoming_ShouldAddTheIncomingToDb()
        {
            var repository = new IncomingRepository();
            var incoming = new Incoming();
            var incomingdById = repository.GetById(incoming.Id);
            Assert.Null(incomingdById);
            repository.Create(incoming);
            incomingdById = repository.GetById(incoming.Id);
            Assert.NotNull(incomingdById);
        }
        [Fact]
        public void TestIncomingDbFindById_WithIncomingId_ShouldFindTheIncomingInDbById()
        {
            var repository = new IncomingRepository();
            var incoming = new Incoming();
            repository.Create(incoming);
            var incomingdById = repository.GetById(incoming.Id);
            Assert.Equal(incoming.Id, incomingdById.Id);
        }
        [Fact]
        public void TestIncomingDbUbdate_WithNewIncoming_ShouldUpdateTheIncomingToDb()
        {
            var repository = new IncomingRepository();
            var incoming = new Incoming();
            repository.Create(incoming);
            var incomingdById = repository.GetById(incoming.Id);
            Assert.Null(incomingdById.Warehouse.Description);
            var warehouse = new Warehouse("warehouse name");
            incoming.Warehouse = warehouse;
            repository.Update(incoming);
            Assert.Equal("warehouse name", incomingdById.Warehouse.Description);
        }
        [Fact]
        public void TestIncomingDbDelete_WithIncoming_ShouldDeleteTheIncomingFromDb()
        {
            var repository = new IncomingRepository();
            var incoming = new Incoming();
            repository.Create(incoming);
            var incomingdById = repository.GetById(incoming.Id);
            Assert.NotNull(incomingdById);
            repository.Delete(incoming.Id);
            incomingdById = repository.GetById(incoming.Id);
            Assert.Null(incomingdById);
        }
    }
}
