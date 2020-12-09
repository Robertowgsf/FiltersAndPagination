using FiltersAndPagination.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FiltersAndPagination.API.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services)
        {
            services.AddDbContext<FiltersAndPaginationContext>(options =>
            {
                options.UseInMemoryDatabase("FiltersAndPagination");
            });
        }
    }
}