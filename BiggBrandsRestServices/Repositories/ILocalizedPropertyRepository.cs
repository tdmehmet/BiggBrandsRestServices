using System;
using System.Collections.Generic;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsRestServices.Repositories
{
    public interface ILocalizedPropertyRepository : IGenericRepository<LocalizedProperty>
    {
        List<LocalizedProperty> FindlocalizedPropertiesByLocaleKeyGroup(string localeKeyGroup);
    }
}
