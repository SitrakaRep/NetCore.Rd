using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using NetCore.Rd.Business.Services.Implementation;
using NetCore.Rd.Business.Services.Interfaces;
using NetCore.Rd.Data.Context;

namespace NetCore.Rd.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public DbContextOptions<ApplicationContext> BuildOptions
        {
            get
            {
                DbContextOptionsBuilder<ApplicationContext> build = new DbContextOptionsBuilder<ApplicationContext>();
                return build.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCore.Rd.Web"))
                        .UseLoggerFactory(MyLoggerFactory)
                        .Options;
            }
        }
        public ApplicationContext ContextInstance
        {
            get
            {
                return new ApplicationContext(this.BuildOptions);
            }
        }

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information, true)
            });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NetCore.Rd.Web")));

            services.AddSingleton<IApartmentService, ApartmentService>(_ => new ApartmentService(ContextInstance));
            services.AddSingleton<IOwnerService, OwnerService>(_ => new OwnerService(ContextInstance));
            // Data Mapper
            services.AddAutoMapper();

            // Data Protection
            services.AddDataProtection();
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
