using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Enums;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class AccountingPolicyTests
    {
        private readonly IDb _db;
        private readonly IRegisterRepository<AccountingPolicy> _accountingPolicyRepository;

        public AccountingPolicyTests()
        {
            _db = new State();
            _accountingPolicyRepository = new RegisterRepositiry<AccountingPolicy>(_db);
            _db.Initialize();
        }

        [Fact]
        public void Test_AccountingPolicy_WithNoData_ShouldContainsData()
        {
            var accountingPolicyList = _db.GetTable<AccountingPolicy>();

            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Main"), "FIFO"));
            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Additional"), "LIFO"));
            accountingPolicyList.Add(CreateAccountingPolicyItem(SelectWarehouse("Main"), "ARVG"));

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

        private AccountingPolicy CreateAccountingPolicyItem(Warehouse warehouse, string writeOffMethodName)
        {
            var accountingPolicy = new AccountingPolicy();
            accountingPolicy.Warehouse = warehouse;
            accountingPolicy.WriteMethod = WriteOffMethod.GetWriteMethod(writeOffMethodName);


            return accountingPolicy;
        }
    }
}
