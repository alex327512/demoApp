using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;


namespace StudyingProgect.ApplicationCore.Services
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
            foreach (var item in incoming.ListOfNomenc)
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
