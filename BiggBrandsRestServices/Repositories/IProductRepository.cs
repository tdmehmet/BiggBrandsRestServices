using System;
using System.Collections.Generic;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> FindProductsByLogoCodePrefix(string logoCodePrefix);
    }
}
