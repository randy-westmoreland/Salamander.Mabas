using Microsoft.AspNetCore.Builder;

namespace Salamander.Mabas.Client.Configurations
{
    /// <summary>
    /// RouteConfig Class.
    /// </summary>
    public static class RouteConfig
    {
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}