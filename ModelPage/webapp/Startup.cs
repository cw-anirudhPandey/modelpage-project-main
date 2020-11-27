using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AEPLCore.Cache.Extensions;
using AutoMapper;
using AEPLCore.Logging;
using ModelPage.Business;

namespace webapp
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
      // string consulHost = Environment.GetEnvironmentVariable("CONSUL_HOST") ?? "127.0.0.1";
      string consulHost = Environment.GetEnvironmentVariable("CONSUL_HOST") ?? "10.10.20.113";
      services.AddControllers();
      services.AddAutoMapper(typeof(Startup));

      services.AddLogging();
      Console.WriteLine(consulHost + "-------------------------" + Configuration["AppSettings:ModuleName"]);
      services.AddLogUpdater(consulHost + ":8500", Configuration["AppSettings:ModuleName"]);
      services.AddSingleton<IModelPageRepository, ModelPageRepository>();
      services.AddSingleton<IModelPageLogic, ModelPageLogic>();
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
      app.UseCors(x => x
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .SetIsOriginAllowed(origin => true) // allow any origin
                      .AllowCredentials());
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        // endpoints.MapControllers();
        endpoints.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}