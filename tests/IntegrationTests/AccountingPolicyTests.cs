using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Enums;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using StudyingProgect.Infrastucture.RegistersRepositories.Information;
using Xunit;
using static StudyingProgect.ApplicationCore.Enums.WriteOffMethod;

namespace StudyingProgect.IntegrationTests
{
    public class AccountingPolicyTests
    {
        private readonly IDb _db;
        private readonly IRegisterRepository<AccountingPolicy> _accountingPolicyRepository;

        public AccountingPolicyTests()
        {
            _db = new State();
            _accountingPolicyRepository = new AccountingPolicyRegisterRepository(_db);
            _db.Initialize();
        }

        [Fact]
        public void Test_AccountingPolicy_WithNoData_ShouldContainsData()
        {
            var accountingPolicyList = _db.GetTable<AccountingPolicy>();

            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Main"), WriteMethod.FIFO));
            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Additional"), WriteMethod.LIFO));
            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Main"), WriteMethod.AVRG));

            Assert.NotNull(accountingPolicyList);

            var currentAccountingPolicy = accountingPolicyList.Where(p => p.Warehouse.Description == "Main");

            Assert.NotNull(accountingPolicyList);
        }

        private Nomenclature SelectNomenclature(string nomenclatureName)
        {
            var nomenclature = _db.GetTable<Nomenclature>();
            var selectedNomenclature = nomenclature.Single(n => n.Description == nomenclatureName);
            return selectedNomenclature;
        }
        private Warehouse SelectWarehouse(string warehouseName)
        {
            var warehouse = _db.GetTable<Warehouse>();
            var selectedWarehouse = warehouse.Single(n => n.Description == warehouseName);
            return selectedWarehouse;
        }

        private AccountingPolicy CreateAccountingPolicyItem(Warehouse warehouse, WriteMethod writeMethod)
        {
            var accountingPolicy = new AccountingPolicy();
            accountingPolicy.Warehouse = warehouse;
            accountingPolicy.WriteMethod = writeMethod;


            return accountingPolicy;
        }
    }
}
