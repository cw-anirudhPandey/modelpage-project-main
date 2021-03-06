﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AEPLCore.Cache.Extensions;
using MMV.DataAccess.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMV.Business;
using MMV.Business.Interfaces;
using MMV.DataAccess;
using MMV.DataAccess.Interfaces;
using MMV.Service.Controller;

namespace Service
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddGrpc();
      services.AddSingleton<ICarMakeRepository, CarMakeRepository>();
      services.AddSingleton<ICarModelRepository, CarModelRepository>();
      services.AddSingleton<ICarVersionRepository, CarVersionRepository>();
      services.AddSingleton<ICarMakeLogic, CarMakeLogic>();
      services.AddSingleton<ICarModelLogic, CarModelLogic>();
      services.AddSingleton<ICarVersionLogic, CarVersionLogic>();
      services.AddCacheConfiguration(Configuration);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapGrpcService<MMVService>();

        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
              });
      });
    }
  }
}
