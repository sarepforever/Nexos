using BibliotecaApi.DTOs;
using BibliotecaApi.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace BibliotecaApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200");
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "BibliotecaApi",
                    Description = "Prueba Tecnica Nexos",
                    Contact = new OpenApiContact()
                    {
                        Name="Santiago Perea Restrepo",
                        Email="sperearestrepo@gmail.com",                        
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(configAction =>
            {
                configAction.CreateMap<TblAutor, POSTAutorDTO>().ReverseMap();
                configAction.CreateMap<TblAutor, GETAutorDTO>().ReverseMap();               
                configAction.CreateMap<TblEditorial, POSTEditorialDTO>().ReverseMap();
                configAction.CreateMap<TblEditorial, GETEditorialDTO>().ReverseMap();
                configAction.CreateMap<TblLibro, POSTLibroDTO>().ReverseMap();
                configAction.CreateMap<TblLibro, GETLibroDTO>().ReverseMap();              
            }, typeof(Startup));

            services.AddDbContext<DbContextBiblioteca>( options=>
            options.UseSqlServer(Configuration.GetConnectionString("DesarolloDB"))
            .UseLazyLoadingProxies()
            );
            services.AddMvc().AddNewtonsoftJson(options => 
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BibliotecaApi v1"));
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
