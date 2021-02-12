﻿using AutoMapper;
using CityInfo.APi.Contexts;
using CityInfo.APi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.APi
{
    public class Startup
    {
        public IConfiguration Config { get; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc().AddMvcOptions(o =>

            {
                o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            
            }
            );



            /*AddJsonOptions(o => { if (o.SerializerSettings.ContractResolver != null) {

                    var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;

                    castedResolver.NamingStrategy = null;          
                    } });*/

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
             services.AddTransient< IMailService,CloudMailService>();
#endif

           
            services.AddDbContext<CityInfocontext>(o => {

                o.UseSqlServer(Config.GetConnectionString("cityInfoDBConnectionsString"));
            });

            services.AddScoped<ICityInfoRepository, CityInfoRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseMvc();

        }
    }
}