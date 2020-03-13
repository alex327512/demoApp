using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Catalogs;
using StudyingProgect.ApplicationCore.Entities.Registers.Information;
using StudyingProgect.ApplicationCore.Interfaces;
using StudyingProgect.Infrastucture;
using Xunit;

namespace StudyingProgect.IntegrationTests
{
    public class SpecificationTests
    {
        private readonly IDb _db;
        private readonly IRegisterRepository<Specification> _specificationRepository;

        public SpecificationTests()
        {
            _db = new State();
            _specificationRepository = new RegisterRepositiry<Specification>(_db);
            _db.Initialize();
        }

        [Fact]
        public void Test_Specification_WithNoData_ShouldContainsData()
        {
            var specificationList = _db.GetTable<Specification>();
            var selectedKit = SelectKit("TYPE-A");

            specificationList.Add(CreateSpecificationItem(SelectNomenclature("AMD"), selectedKit, 30));
            specificationList.Add(CreateSpecificationItem(SelectNomenclature("NVIDIA"), selectedKit, 60));
            specificationList.Add(CreateSpecificationItem(SelectNomenclature("WD"), selectedKit, 20));

            var result = specificationList.GroupBy(s => s.Kit);

            Assert.NotNull(result);

        }

        private Nomenclature SelectNomenclature(string nomenclatureName)
        {
            var nomenclature = _db.GetTable<Nomenclature>();
            var selectedNomenclature = nomenclature.Single(n => n.Description == nomenclatureName);
            return selectedNomenclature;
        }

        private Nomenclature SelectKit(string kitName)
        {
            var kit = _db.GetTable<Nomenclature>();
            var selectedKit = kit.Single(n => n.Description == kitName);
            return selectedKit;
        }

        private Specification CreateSpecificationItem(Nomenclature nomenclature, Nomenclature kit, decimal amount)
        {
            var specification = new Specification();
            specification.Component = nomenclature;
            specification.Kit = kit;
            specification.Amount = amount;
            return specification;
        }
    }
}
