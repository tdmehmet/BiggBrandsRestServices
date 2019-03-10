using System;
using System.Collections.Generic;
using System.Linq;
using BiggBrandsExchangeRateApp.Services.CampaignManagement;
using BiggBrandsRestServices.Dtos;
using BiggBrandsRestServices.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BiggBrandsRestServices.Controllers
{
    [Route(Constants.API_VERSION + "/justlounge")]
    public class JustLoungeBiggBrandsController : Controller
    {

        private readonly IProductService _productService;

        public JustLoungeBiggBrandsController(IProductService productService) {
            _productService = productService;
        }

        // GET api/values
        [HttpGet]
        [Route("findProductList")]
        public ActionResult<IEnumerable<ProductDto>> FindProductList()
        {
            return _productService.FindProductsByLogoCodePrefix("BGD").ToArray();
        }

       
    }
}
