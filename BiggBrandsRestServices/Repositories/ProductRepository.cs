using System.Linq;
using System.Collections.Generic;
using BiggBrandsRestServices.Config;
using BiggBrandsRestServices.Repositories;
using BiggBrandsRestServices.BiggBrands;
using BiggBrandsRestServices.Dtos;
using BiggBrandsRestServices.Utils;
using Microsoft.EntityFrameworkCore;

namespace BiggBrandsRestServices.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public List<Product> FindProductsByLogoCodePrefix(string logoCodePrefix)
        {
            return this._entities.Product
                .Where(p => p.Sku.StartsWith(logoCodePrefix))
                .Include(p=> p.ProductManufacturerMapping).ThenInclude(pm => pm.Manufacturer)
                .Include(p => p.ProductCategoryMapping).ThenInclude(pc => pc.Category)
                .Include(p => p.ProductPictureMapping).ThenInclude(ppm => ppm.Picture)
                .ToList();
        }
    }
}
