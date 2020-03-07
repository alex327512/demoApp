using StudyingProgect.ApplicationCore;
using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;
using Xunit;


namespace StudyingProgect.RepositoryTests.IntegrationTests
{

    public class IncomingRepositoryTests
    {
        private readonly IDb _db;

        public IncomingRepositoryTests()
        {
            _db = new State();
        }

        [Fact]
        public void TestIncomingDbAdd_WithNewIncoming_ShouldAddTheIncomingToDb()
        {
            var repository = new RepositoryBase<Incoming>(_db);
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
            var repository = new RepositoryBase<Incoming>(_db);
            var incoming = new Incoming();
            repository.Create(incoming);
            var incomingdById = repository.GetById(incoming.Id);
            Assert.Equal(incoming.Id, incomingdById.Id);
        }

        [Fact]
        public void TestIncomingDbUbdate_WithNewIncoming_ShouldUpdateTheIncomingToDb()
        {
            var repository = new RepositoryBase<Incoming>(_db);
            var incoming = new Incoming();
            repository.Create(incoming);
            var incomingdById = repository.GetById(incoming.Id);
            Assert.Null(incomingdById.Warehouse);
            var warehouse = new Warehouse("warehouse name");
            incoming.Warehouse = warehouse;
            repository.Update(incoming);
            Assert.Equal("warehouse name", incomingdById.Warehouse.Description);
        }

        [Fact]
        public void TestIncomingDbDelete_WithIncoming_ShouldDeleteTheIncomingFromDb()
        {
            var repository = new RepositoryBase<Incoming>(_db);
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
