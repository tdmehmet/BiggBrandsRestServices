using System;
using System.Collections.Generic;

namespace BiggBrandsRestServices.BiggBrands
{
    public partial class ExchangeRateHistory
    {
        public int Id { get; set; }
        public int? CurrencyId { get; set; }
        public double? Rate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
