using AirLineMicroservices.Consumer;
using AirLineMicroservices.Interface;
using AirLineMicroservices.Models;
using AirLineMicroservices.Services;
using AirLineMicroservices.ViewModel;
using Common;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AirLineMicroservices
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
            services.AddCors();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(o => {
            //    var key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
            //    o.SaveToken = true;
            //    o.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false,
            //        ValidateIssuer = false,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = Configuration["JWT:Issuer"],
            //        ValidAudience = Configuration["JWT:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(key)
            //    };
            //});
            services.AddScoped<IRegisterAirline, RegisterAirlineImpl>();
            services.AddScoped<IAddInventory, AddInventoryImpl>();
            services.AddDbContext<AirLineInventoryDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("AirLineInventoryDBConection")));
            services.AddConsulConfig(Configuration);
            
            services.AddMassTransit(x => {
                x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
                x.AddRider(rider => {
                    rider.AddConsumer<UpdateFlightInventoryConsumer>();
                    rider.UsingKafka((context, k) =>
                    {
                        k.Host("localhost:9092");
                        k.TopicEndpoint<FlightDetails>(nameof(FlightDetails), GetUniqueName(nameof(FlightDetails)), e => {
                            e.CheckpointInterval = TimeSpan.FromSeconds(10);
                            e.ConfigureConsumer<UpdateFlightInventoryConsumer>(context);
                        });
                    });
                });
            });
            services.AddMassTransitHostedService();
            services.AddSwaggerGen();
            
            
        }
        private string GetUniqueName(string eventname)
        {
            string hostname = Dns.GetHostName();
            string classAssembly = Assembly.GetCallingAssembly().GetName().Name;
            return $"{hostname}.{classAssembly}.{eventname}";

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
             );
            app.UseConsul(Configuration);
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();
           // app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
