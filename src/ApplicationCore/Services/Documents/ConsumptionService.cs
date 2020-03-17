using System.Collections.Generic;
using System.Linq;
using StudyingProgect.ApplicationCore.Entities.Documents;
using StudyingProgect.ApplicationCore.Entities.Registers.Accumulation;
using StudyingProgect.ApplicationCore.Interfaces;
using static StudyingProgect.ApplicationCore.Enums.ExpenseEnum;

namespace StudyingProgect.ApplicationCore.Services.Documents
{
    public class ConsumptionService
    {
        private readonly IRepository<Consumption> _repository;
        private readonly IRegisterRepository<RemainNomenclature> _remainNomenclature;
        private readonly IRegisterRepository<RemainCostPrice> _remainCostPrice;
        private readonly List<RemainNomenclature> _table;


        public ConsumptionService(IRepository<Consumption> repository, IRegisterRepository<RemainNomenclature> remainNomenclature, IRegisterRepository<RemainCostPrice> remainCostPrice, IDb db)
        {
            _repository = repository;
            _remainNomenclature = remainNomenclature;
            _remainCostPrice = remainCostPrice;
            _table = db.GetTable<RemainNomenclature>();

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
                var availableQuantity = _table
                     .Where(t => t.Nomenclature.Id == item.Nomenclature.Id)
                     .Select(q => q.Quantity)
                     .ToList();
                if (availableQuantity[0] < item.Quantity)
                {
                    throw new System.ArgumentException("Not enough goods in warehouse");
                }
                var recordNomenclature = new RemainNomenclature
                {
                    Nomenclature = item.Nomenclature,
                    RecordType = RecordType.Expose,
                    Quantity = item.Quantity,
                    Warehouse = consumption.Warehouse
            };

                var recordCostPrice = new RemainCostPrice
                {
                    Nomenclature = item.Nomenclature,
                    Amount = item.Quantity,
                    Sum = item.Sum,
                    RecordType = RecordType.Expose,
                };

                _remainNomenclature.Create(recordNomenclature);
                _remainCostPrice.Create(recordCostPrice);
            }

            _repository.Create(consumption);
            _remainNomenclature.RecalcBalances();
            _remainCostPrice.RecalcBalances();
        }
    }
}
