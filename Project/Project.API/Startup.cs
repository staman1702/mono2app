using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.DAL;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;

namespace Project.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<AppDbContext>
                (item => item.UseSqlServer(Configuration.GetConnectionString("AppConn")));


            services.AddScoped<IVehicleMakeRepository, VehicleMakeRepository>();
            services.AddScoped<IVehicleModelRepository, VehicleModelRepository>();


            services.AddScoped<IVehicleMakeService, VehicleMakeService>();
            services.AddScoped<IVehicleModelService, VehicleModelService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
