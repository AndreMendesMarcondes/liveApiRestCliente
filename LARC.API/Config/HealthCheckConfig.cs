using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LARC.API.Config
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services, IConfiguration config)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder
                .AddCheck("self", () => HealthCheckResult.Healthy());
            hcBuilder.AddMongoDb(mongodbConnectionString: config["MongoDbSettings:ConnectionString"]);

            return services;
        }
    }
}
