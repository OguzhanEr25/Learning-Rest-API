using HotelFinder.Business_.Abstract;
using HotelFinder.Business_.Concreate;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API_
{
    public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<IHotelService, HotelManager>();
        services.AddSingleton<IHotelRepository, HotelRepository>();
        services.AddSwaggerDocument(config =>
        {
            config.PostProcess = (Doc =>
            {
                Doc.Info.Title = "All Hotels Api";
                Doc.Info.Version = "1.0.13";
                Doc.Info.Contact = new NSwag.OpenApiContact()
                {
                    Name = "Oðuzhan Er",
                    Url = "https://www.linkedin.com/in/o%C4%9Fuzhan-er-248993209/",
                    Email = "oguz.er2525@gmail.com"
                };
            });
        });
    }

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseOpenApi();
        app.UseSwaggerUi3();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
