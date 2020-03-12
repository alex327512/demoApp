using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class ConsumptionService
    {
        private readonly IRepository<Consumption> _repository;
        private readonly IRepository<RemainNomenclature> _remainNomenclature;
        private readonly IRepository<RemainCostPrice> _remainCostPrice;

        public ConsumptionService(IRepository<Consumption> repository, IRepository<RemainNomenclature> remainNomenclature, IRepository<RemainCostPrice> remainCostPrice)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;
            _remainCostPrice = remainCostPrice;

        }

        public void Write(Consumption consumption)
        {
            var select = consumption.ListOfNomenc.GroupBy(i => i.Nomenclature).Select(g => new LineItem()
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
                    Amount = item.Quantity,
                    Sum = item.Sum,
                    RecordType = RecordType.Expose,
                };

                recordNomenclature.Warehouse = consumption.Warehouse;
                _remainNomenclature.Create(recordNomenclature);
                _remainCostPrice.Create(recordCostPrice);
            }

            _repository.Create(consumption);
        }
    }
}
