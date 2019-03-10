using BiggBrandsRestServices.Dtos;
using BiggBrandsRestServices.Repositories;
using log4net;
using System.Linq;
using System.Collections.Generic;
using BiggBrandsRestServices.Utils;
using BiggBrandsRestServices.BiggBrands;

namespace BiggBrandsExchangeRateApp.Services.CampaignManagement
{
    public class ProductService : IProductService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ProductService));
        private readonly IProductRepository _productRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ILocalizedPropertyRepository _localizedPropertyRepository;

        public ProductService(IProductRepository productRepository,
            ICurrencyRepository currencyRepository,
            ILocalizedPropertyRepository localizedPropertyRepository)
        {
            _productRepository = productRepository;
            _currencyRepository = currencyRepository;
            _localizedPropertyRepository = localizedPropertyRepository;
        }

        public List<ProductDto> FindProductsByLogoCodePrefix(string logoCodePrefix)
        {
            List<Currency> currencies = _currencyRepository.FindAllItems();
            List<LocalizedProperty> localizedProperties = _localizedPropertyRepository.FindlocalizedPropertiesByLocaleKeyGroup(Constants.LOCALIZED_PROPERTY_LOCALE_KEY_GROUP_PRODUCT);
            return _productRepository.FindProductsByLogoCodePrefix(logoCodePrefix)
                .Select(
                    p => new ProductDto()
                    {
                        AdminComment = p.AdminComment,
                        TurkishFullDescription = p.FullDescription,
                        EnglishFullDescription = localizedProperties.Where(lp => lp.EntityId == p.Id &&
                            lp.LanguageId == Constants.LANGUAGE_ID_ENGLISH && lp.LocaleKey == Constants.LOCALIZED_PROPERTY_LOCALE_KEY_FULL_DESCRIPTION)
                            .FirstOrDefault()?.LocaleValue,
                        Height = p.Height,
                        Length = p.Length,
                        Id = p.Id,
                        MetaDescription = p.MetaDescription,
                        MetaKeywords = p.MetaKeywords,
                        MetaTitle = p.MetaTitle,
                        TurkishName = p.Name,
                        EnglishName = localizedProperties.Where(lp => lp.EntityId == p.Id &&
                            lp.LanguageId == Constants.LANGUAGE_ID_ENGLISH && lp.LocaleKey == Constants.LOCALIZED_PROPERTY_LOCALE_KEY_NAME)
                            .FirstOrDefault()?.LocaleValue,
                        Category = p.ProductCategoryMapping?.FirstOrDefault()?.Category?.Name,
                        PictureUrls = p.ProductPictureMapping.ToList().Select(ppm => Constants.SANALMAGAZA_CONTENT_URL + ppm.Picture.SeoFilename).ToList(),
                        TurkishShortDescription = p.ShortDescription,
                        EnglishShortDescription = localizedProperties.Where(lp => lp.EntityId == p.Id &&
                            lp.LanguageId == Constants.LANGUAGE_ID_ENGLISH && lp.LocaleKey == Constants.LOCALIZED_PROPERTY_LOCALE_KEY_SHORT_DESCRIPTION)
                            .FirstOrDefault()?.LocaleValue,
                        StockQuantity = p.StockQuantity,
                        Weight = p.Weight,
                        Width = p.Width,
                        PriceAED = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_AED).FirstOrDefault().Rate) ),
                        PriceUSD = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_USD).FirstOrDefault().Rate)),
                        PriceAUD = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_AUD).FirstOrDefault().Rate)),
                        PriceGBP = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_GBP).FirstOrDefault().Rate)),
                        PriceCAD = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_CAD).FirstOrDefault().Rate)),
                        PriceCNY = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_CNY).FirstOrDefault().Rate)),
                        PriceEUR = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_EUR).FirstOrDefault().Rate)),
                        PriceHKD = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_HKD).FirstOrDefault().Rate)),
                        PriceJPY = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_JPY).FirstOrDefault().Rate)),
                        PriceRUB = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_RUB).FirstOrDefault().Rate)),
                        PriceSEK = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_SEK).FirstOrDefault().Rate)),
                        PriceINR = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_INR).FirstOrDefault().Rate)),
                        PriceTL = MathsUtil.CalculatePrice(ConversionUtil.ConvertDecimalToDouble(p.Price),
                            ConversionUtil.ConvertDecimalToDouble(currencies.Where(c => c.Id == Constants.CURRENCY_ID_TL).FirstOrDefault().Rate))
                    }
                ).ToList();
        }
    }
}
