using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservico_Crud.DBContexts;
using Microservico_Crud.Repository;
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

namespace Microservico_Crud
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

            services.AddMvc().AddNewtonsoftJson();
            //services.AddControllers().AddNewtonsoftJson();
            //services.AddControllersWithViews().AddNewtonsoftJson();
            //services.AddRazorPages().AddNewtonsoftJson();

            services.AddDbContext<CaseContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ProductDB")));
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ICaseRepository, CaseRepository>();

            services.AddSwaggerGen(
            swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Description = "API REST desenvolvida em .NET CORE",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Larissa Bredo",
                        Url = new Uri("https://github.com/Laribredo"),
                          //Email = ""
                      }
                });


            }
            );
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
            app.UseSwagger();
            app.UseSwaggerUI(swagger => { swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "Larissa Bredo"); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
