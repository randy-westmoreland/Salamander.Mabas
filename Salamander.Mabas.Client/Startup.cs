using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Salamander.Mabas.Client.Configurations;
using Salamander.Mabas.Model.AppSettings;

namespace Salamander.Mabas.Client
{
    /// <summary>
    /// Startup Class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthorizationSettings>(Configuration.GetSection("AuthorizationSettings"));
            services.Configure<OrganizationSettings>(Configuration.GetSection("OrganizationSettings"));
            services.Configure<UserSettings>(Configuration.GetSection("UserSettings"));

            services.AddControllersWithViews();
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");

            DependencyConfig.ConfigureServices(services, Configuration);
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            RouteConfig.Configure(app);
            AngularConfig.Configure(app, env);
        }
    }
}