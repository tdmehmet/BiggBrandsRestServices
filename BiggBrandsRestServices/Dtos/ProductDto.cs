using BiggBrandsRestServices.BiggBrands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiggBrandsRestServices.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string TurkishName { get; set; }
        public string TurkishShortDescription { get; set; }
        public string TurkishFullDescription { get; set; }
        public string EnglishName { get; set; }
        public string EnglishShortDescription { get; set; }
        public string EnglishFullDescription { get; set; }
        public string AdminComment { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public int StockQuantity { get; set; }
        public double PriceUSD { get; set; }
        public double PriceAUD { get; set; }
        public double PriceGBP { get; set; }
        public double PriceCAD { get; set; }
        public double PriceCNY { get; set; }
        public double PriceEUR { get; set; }
        public double PriceHKD { get; set; }
        public double PriceJPY { get; set; }
        public double PriceRUB { get; set; }
        public double PriceSEK { get; set; }
        public double PriceINR { get; set; }
        public double PriceTL { get; set; }
        public double PriceAED { get; set; }

        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public string Category { get; set; }
        public List<string> PictureUrls { get; set; }
    }
}
