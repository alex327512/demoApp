using StudyingProgect.ApplicationCore.Models;
using StudyingProgect.Infrastucture;

namespace StudyingProgect.ApplicationCore.Services
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
                    
                };
                _remainNomenclature.Create(record);
            }


            _repository.Create(consumption);
        }
    }
}
