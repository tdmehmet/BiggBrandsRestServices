using System.Linq;
using System.Collections.Generic;
using BiggBrandsRestServices.Config;
using BiggBrandsRestServices.Repositories;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public class LocalizedPropertyRepository : GenericRepository<LocalizedProperty>, ILocalizedPropertyRepository
    {
        public LocalizedPropertyRepository(BiggBrandsContext biggBrandsContext) : base(biggBrandsContext)
        {
        }

        public List<LocalizedProperty> FindlocalizedPropertiesByLocaleKeyGroup(string localeKeyGroup)
        {
            return this._entities.LocalizedProperty.Where(lp => lp.LocaleKeyGroup == localeKeyGroup).ToList();
        }

    }
}
