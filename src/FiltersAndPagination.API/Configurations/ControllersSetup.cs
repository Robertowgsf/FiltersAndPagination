using Microsoft.Extensions.DependencyInjection;

namespace FiltersAndPagination.API.Configurations
{
    public static class ControllersSetup
    {
        public static void AddControllersSetup(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
        }
    }
}
