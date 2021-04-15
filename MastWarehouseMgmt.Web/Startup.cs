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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MastDatabase")));

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MastDatabase")));
            services.AddIdentity<User, IdentityRole>()
                                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductionHistoryRepository, ProductionHistoryRepository>();
            services.AddScoped<IMaterialHistoryRepository, MaterialHistoryRepository>();
            services.AddScoped<ISaleHistoryRepository, SaleHistoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddAutoMapper(typeof(Startup).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
