using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FiltersAndPagination.API.Infrastructure
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Includes<T>(this IQueryable<T> query, params string[] includes)
            where T : class
        {
            if (includes == null)
            {
                return query;
            }

            query = query.Include(string.Join(", ", includes));

            return query;
        }
    }
}
