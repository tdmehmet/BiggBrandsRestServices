using System;
using System.Collections.Generic;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public interface IExchangeRateHistoryRepository : IGenericRepository<ExchangeRateHistory>
    {
        double FindLatestExchangeRate(int currencyId);
    }
}
