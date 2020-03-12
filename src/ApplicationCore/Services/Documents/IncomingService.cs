using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;
using System.Linq;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class IncomingService
    {
        private readonly IRepository<Incoming> _repository;
        private readonly IRepository<RemainNomenclature> _remainNomenclature;
        private readonly IRepository<RemainCostPrice> _remainCostPrice;

        public IncomingService(IRepository<Incoming> repository, IRepository<RemainNomenclature> remainNomenclature, IRepository<RemainCostPrice> remainCostPrice)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;
            _remainCostPrice = remainCostPrice;

        }

        public void Write(Incoming incoming)
        {
            var select = incoming.ListOfNomenc.GroupBy(i => i.Nomenclature).Select(g => new LineItem()
            {
                Nomenclature = g.Key,
                Quantity = g.Sum(i => i.Quantity),
                Sum = g.Sum(i => i.Sum)
            }) ;

            foreach (var item in select)
            {
                var recordNomenclature = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Receipt,
                    Quantity = item.Quantity,
                };

                var recordCostPrice = new RemainCostPrice
                {
                    Nomenclature = item.Nomenclature,
                    Amount = item.Quantity,
                    Sum = item.Sum,
                    RecordType = RecordType.Receipt,
                };

                recordNomenclature.Warehouse = incoming.Warehouse;
                _remainNomenclature.Create(recordNomenclature);
                _remainCostPrice.Create(recordCostPrice);
            }

            _repository.Create(incoming);
        }
    }
}
