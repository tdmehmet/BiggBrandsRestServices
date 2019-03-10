using System.Linq;
using System.Collections.Generic;
using BiggBrandsRestServices.Config;
using BiggBrandsRestServices.Repositories;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public class ExchangeRateHistoryRepository : GenericRepository<ExchangeRateHistory>, IExchangeRateHistoryRepository
    {
        public ExchangeRateHistoryRepository(BiggBrandsContext smMenaProductDBContext) : base(smMenaProductDBContext)
        {
        }

        public double FindLatestExchangeRate(int currencyId)
        {
            ExchangeRateHistory exchangeRateHistory = this._entities.ExchangeRateHistory.Where(erh => erh.CurrencyId == currencyId)
                .OrderByDescending(erh => erh.CreatedDate).FirstOrDefault();

            return exchangeRateHistory == null ? 1 : exchangeRateHistory.Rate.Value;
        }
    }
}
