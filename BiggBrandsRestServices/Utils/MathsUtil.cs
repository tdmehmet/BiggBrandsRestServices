using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiggBrandsRestServices.Utils
{
    public static class MathsUtil
    {
        public static double CalculatePrice(double buyingPrice, double exchangeRate)
        {
            return buyingPrice * (1 + Constants.MARJ / 100) * (1 / exchangeRate);
        }
    }
}
