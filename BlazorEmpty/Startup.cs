using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BlazorEmpty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = "Host=localhost;Port=5432;Database=66bitFootballer;Username=postgres;Password=Kot_Kuzma1";
            var connection = "Host=postgres;Port=5432;Database=66bitFootballer;Username=postgres;Password=Kot_Kuzma1";
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddAntDesign();
            services.AddDbContext<EFDBContext>(op => op.UseNpgsql(connection, b => b.MigrationsAssembly("DataLayer").SetPostgresVersion(new Version(9,6))));
            services.AddScoped<IRepository<Footballer>, EFFootballerRepository>();
            services.AddScoped<IRepository<Team>, EFRepository<Team>>();
            services.AddScoped<DataManager>();
            services.AddScoped<TeamService>();
            services.AddScoped<FootballerService>();
            services.AddSingleton<FootbalListService>();
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
