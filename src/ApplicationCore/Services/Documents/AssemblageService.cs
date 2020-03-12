using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class AssemblageService
    {
        private readonly IRepository<Assemblage> _repository;
        private readonly IRepository<RemainNomenclature> _remainNomenclature;
        private readonly IRepository<RemainCostPrice> _remainCostPrice;

        public AssemblageService(IRepository<Assemblage> repository, IRepository<RemainNomenclature> remainNomenclature, IRepository<RemainCostPrice> remainCostPrice)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;
            _remainCostPrice = remainCostPrice;
        }

        public void Write(Assemblage assemblage)
        {
            var select = assemblage.ListOfNomenc.GroupBy(i => i.Nomenclature).Select(g => new LineItem()
            {
                Nomenclature = g.Key,
                Quantity = g.Sum(i => i.Quantity),
                Sum = g.Sum(i => i.Sum)
            });

            foreach (var item in select)
            {
                var recordNomenclature = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Expose,
                    Quantity = item.Quantity,
                };
                var recordCostPrice = new RemainCostPrice
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Expose,
                    Amount = item.Quantity,
                };

                recordNomenclature.Warehouse = assemblage.Warehouse;
                _remainNomenclature.Create(recordNomenclature);
                _remainCostPrice.Create(recordCostPrice);
            }
            _repository.Create(assemblage);
        }
    }
}
