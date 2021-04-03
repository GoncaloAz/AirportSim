using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportSimulatorBackend.Models;
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
using AirportSimulatorBackend.Repository;
using AirportSimulatorBackend.Services;

namespace AirportSimulatorBackend
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

            services.AddCors(opt =>
            {
                opt.AddPolicy("MyPolicy", c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            //Connection string for exercise purpose
            const string postgresConnectionString = @"
                Host=tai.db.elephantsql.com;
                Port=5432;
                Username=yslhojbi;
                Password=qoaYmQi40_m7FKSC5rJLRg_Fzan10ZJ7;
                Database=yslhojbi;
                Pooling=true;
                SSL Mode=Require;
                TrustServerCertificate=True;
                ";

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirportSimulatorBackend", Version = "v1" });
            });

            services.AddDbContext<ApiContext>(opt => opt.UseNpgsql(postgresConnectionString));

            services.AddHttpClient();
            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IRequestService, RequestService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirportSimulatorBackend v1"));
            }



            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
