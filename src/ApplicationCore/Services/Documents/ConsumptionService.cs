using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class ConsumptionService
    {
        private readonly IRepository<Consumption> _repository;
        private readonly IRepository<RemainNomenclature> _remainNomenclature;

        public ConsumptionService(IRepository<Consumption> repository, IRepository<RemainNomenclature> remainNomenclature)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;

        }

        public void Write(Consumption consumption)
        {
            foreach (var item in consumption.ListOfNomenc)
            {
                var record = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Expose,
                    Quantity = item.Quantity,
                };
                record.Warehouse = consumption.Warehouse;
                _remainNomenclature.Create(record);
            }

            _repository.Create(consumption);
        }
    }
}
