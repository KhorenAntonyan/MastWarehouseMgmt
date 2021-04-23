using MastWarehouseMgmt.Data;
using MastWarehouseMgmt.Data.Entities;
using MastWarehouseMgmt.Data.Repositories;
using MastWarehouseMgmt.Data.Repositories.Interfaces;
using MastWarehouseMgmt.Web.Infrastructure.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MastWarehouseMgmt.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation()
                .AddMvcOptions(options =>
                {
                    options.MaxModelValidationErrors = 50;
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "Не указано");
                }); ;

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MastDatabase")));

            services.AddIdentity<User, IdentityRole>()
                                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductionHistoryRepository, ProductionHistoryRepository>();
            services.AddScoped<IMaterialHistoryRepository, MaterialHistoryRepository>();
            services.AddScoped<ISaleHistoryRepository, SaleHistoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
