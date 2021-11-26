using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Users.Persistence;
using Users.WebApi.Mappings;
using Microsoft.OpenApi.Models;
using MediatR;
using System;

namespace Users.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddPersistence(_configuration.GetConnectionString("DbConnection"));
            services.AddAutomapperExt();

            services.AddMediatR(AppDomain.CurrentDomain.Load("Users.Application"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sourceful Test Task", Version = "v1" });
            });

            services.AddCors(options =>
                options.AddPolicy("AllowOrigin", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                })
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sourceful Test Task V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
