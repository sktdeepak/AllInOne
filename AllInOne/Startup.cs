using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.API.Implementation;
using AllInOne.API.Interface;
using AllInOne.Data.Entities;
using AllInOne.Data.Implementation;
using AllInOne.Data.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AllInOne {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();

            services.AddDbContext<AllInOneContext>(options =>
                options.UseSqlServer("Server=.;Database=AllInOne;Trusted_Connection=Yes;"));

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAgricultureService, AgricultureService>();
            services.AddTransient<IPriceService, PriceService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAgricultureRepository, AgricultureRepository>();
            services.AddTransient<IPriceRepository, PriceRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AllInOne API", Version = "v1" });
            });

            services.AddCors(options => {
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").Contains("Development"))
                {
                    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                }
                else
                {
                  
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
            });

            app.UseCors("CorsPolicy");

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
