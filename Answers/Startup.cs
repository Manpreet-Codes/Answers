using Answers.Services.Implementations;
using Answers.Services.Interfaces;
using Answers.Services.Interfaces.Data;
using Answers.Services.Interfaces.ProductSorting;
using Answers.Services.Interfaces.ShoppingProcessor;
using Answers.Services.Interfaces.ShoppingProcessors;
using Answers.Services.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Answers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IHttpDataService, HttpDataService>();
            services.AddScoped<IHttpClientServiceGet, HttpClientServiceGet>();
            services.AddScoped<IHttpClientServicePost, HttpClientServicePost>();
            services.AddScoped<IProductSortingServiceHighPrice, ProductSortingServiceHighPrice>();
            services.AddScoped<IProductSortingServiceLowPrice, ProductSortingServiceLowPrice>();
            services.AddScoped<IProductSortingServiceNameAscending, ProductSortingServiceNameAscending>();
            services.AddScoped<IProductSortingServiceNameDescending, ProductSortingServiceNameDescending>();
            services.AddScoped<IProductSortingServiceNameRecommeded, ProductSortingServiceNameRecommeded>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISortService, SortService>();
            //services.AddScoped<ITrolleyTotalService, TrolleyTotalService>();
            services.AddScoped<IShoppingHistoryProcessor, ShoppingHistoryProcessor>();
            services.AddScoped<IProductProcessor, ProductProcessor>();
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}