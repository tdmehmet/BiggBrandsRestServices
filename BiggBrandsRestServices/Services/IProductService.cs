using System;
using System.Collections.Generic;
using BiggBrandsRestServices.Dtos;

namespace BiggBrandsExchangeRateApp.Services.CampaignManagement
{
    public interface IProductService
    {
        List<ProductDto> FindProductsByLogoCodePrefix(string logoCodePrefix);
    }
}
