using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosSystem.Constants;
using PosSystem.DataAcessLayer;

namespace PosSystem.StartupConfigurations
{
    /// <summary>
    /// TokenAuthenticationMiddleware is an entity which represents the configuration of token based authentication.
    /// </summary>
    public static class DatabaseConfiguration
    {

        /// <summary>
        /// ConfigureTokenBasedAuthentication is the method used for the purpose of configuring
        /// token based authentication.
        /// </summary>
        /// <param name="services">services</param>
        /// <param name="Configuration">configuration</param>
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<PosDbContext>(db => db.UseSqlServer(Configuration
                .GetConnectionString(StartupConfigurationConstant
                .CONNECTION_STRING_KEY)));
        }
    }
}
