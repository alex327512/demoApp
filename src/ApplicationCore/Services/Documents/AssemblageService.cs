using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers;
using StudyingProgect.ApplicationCore.Interfaces;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class AssemblageService
    {
        private readonly IRepository<Assemblage> _repository;
        private readonly IRepository<RemainNomenclature> _remainNomenclature;

        public AssemblageService(IRepository<Assemblage> repository, IRepository<RemainNomenclature> remainNomenclature)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;

        }

        public void Write(Assemblage assemblage)
        {

            foreach (var item in assemblage.ListOfNomenc)
            {
                var record = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Expose,
                    Quantity = item.Quantity,
                };
                record.Nomenclature = assemblage.Nomenclature;
                record.Warehouse = assemblage.Warehouse;
                _remainNomenclature.Create(record);
            }
            _repository.Create(assemblage);
        }
    }
}
