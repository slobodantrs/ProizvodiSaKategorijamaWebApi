using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;
using ProizvodiSaKategorijamaWebApi.Mapping;
using ProizvodiSaKategorijamaWebApi.Services.IServices;
using ProizvodiSaKategorijamaWebApi.Services;
using ProizvodiSaKategorijamaWebApi.Repositories.IRepositories;
using ProizvodiSaKategorijamaWebApi.Repositories;

namespace ProizvodiSaKategorijamaWebApi
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
            string connString = Configuration["ConnectionString:ProductCatalog"];
            var connection = new SqlConnection(connString);
            services.AddTransient<System.Data.IDbConnection>(_ => new SqlConnection(connString));
            services.AddTransient<IKategorijaService,KategorijaService>();
            services.AddTransient<IKategorijaRepository,KategorijaRepository>();
            services.AddTransient<IProizvodService,ProizvodService>();
            services.AddTransient<IProizvodRepository,ProizvodRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                builder =>
                    {
                        builder.WithOrigins("https://localhost:5021", "http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToResourceProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Zdravo ");
                });
            });
        }
    }
}
