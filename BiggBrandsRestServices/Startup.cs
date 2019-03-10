using BiggBrandsRestServices.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BiggBrandsExchangeRateApp.Services.CampaignManagement;
using BiggBrandsRestServices.Repositories;

namespace BiggBrandsRestServices
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BiggBrandsContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BIGGBRANDS_NOPDB")));

            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ILocalizedPropertyRepository, LocalizedPropertyRepository>();
            services.AddTransient<IExchangeRateHistoryRepository, ExchangeRateHistoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
