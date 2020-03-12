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

        public IncomingService(IRepository<Incoming> repository, IRepository<RemainNomenclature> remainNomenclature)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;

        }

        public void Write(Incoming incoming)
        {
            var select = incoming.ListOfNomenc.GroupBy(i => i.Nomenclature).Select(g => new LineItem()
            {
                Nomenclature = g.Key,
                Quantity = g.Sum(i => i.Quantity)
            }) ;

            foreach (var item in select)
            {
                var record = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Receipt,
                    Quantity = item.Quantity,
                };
                record.Warehouse = incoming.Warehouse;
                _remainNomenclature.Create(record);
            }

            _repository.Create(incoming);
        }
    }
}
