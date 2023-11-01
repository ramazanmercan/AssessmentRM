using GuideFinder.Business.Concrete;
using GuideFinder.DataAccess.Abstract;
using GuideFinder.DataAccess.Concrete;
using GuideFinfer.Business.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuideFinder.API
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
            services.AddMvc(); // veya services.AddRazorPages();
            services.AddControllers();
            services.AddSingleton<IGuideDetailService, GuideDetailManager>();
            services.AddSingleton<IGuideDetailRepository, GuideDetailRepository>();

            services.AddSingleton<IGuideService, GuideManager>();
            services.AddSingleton<IGuideRepository, GuideRepository>();

            services.AddSingleton<IReportService, ReportManager>();
            services.AddSingleton<IReportRepository, ReportRepository>();

            services.AddSwaggerDocument(config =>
            config.PostProcess = (doc =>
            {
                doc.Info.Title = "Rehber API";
                doc.Info.Version = "v1";
                doc.Info.Contact = new NSwag.OpenApiContact()
                {
                    Name = "Ramazan MERCAN",
                    Email = "ramazanmercan@outlook.com.tr"
                };
            }));
        }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseOpenApi();

        app.UseSwaggerUi3();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
}
