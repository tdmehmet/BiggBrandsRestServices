using System.Linq;
using System.Collections.Generic;
using BiggBrandsRestServices.Config;
using BiggBrandsRestServices.Repositories;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }
    }
}
