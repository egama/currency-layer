﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Neon.Elivelton.Application.App;
using Neon.Elivelton.Application.Interface;
using Neon.Elivelton.Service;
using Neon.Elivelton.Service.Interface;
using Swashbuckle.AspNetCore.Swagger;

namespace Neon.Elivelton.UI
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
            services.AddMvc();
            services.AddCors();
            services.AddCors(o => o.AddPolicy("PolicyNeon", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Elivelton - Neon - API",
                    Version = "v1",
                    Description = "Conversão de moedas"
                });

                c.IncludeXmlComments(string.Format(@"{0}\Neon.Elivelton.UI.xml",
                           System.AppDomain.CurrentDomain.BaseDirectory));
            });

            services.AddTransient<ICurrencyLayer, CurrencyLayer>();
            services.AddTransient<ICurrency, Currency>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("PolicyNeon");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Elivelton - Neon - API");
            });

            app.UseMvc();
        }
    }
}
