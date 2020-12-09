using FiltersAndPagination.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersAndPagination.API.Domain.Core
{
    public abstract class QueryController<TEntity, TFilter> : ControllerBase
        where TEntity : Entity
        where TFilter : Filter
    {
        protected readonly FiltersAndPaginationContext _context;

        public QueryController(FiltersAndPaginationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TFilter filter)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            query = Filter(query, filter);
            query = Paginate(query, filter);
            query = query.Includes(filter.Includes);

            var pagedResponse = new PagedResponse<TEntity>
            {
                Items = await query.ToListAsync(),
                NextPage = GetNextPage(filter),
                PreviousPage = GetPreviousPage(filter)
            };

            return Ok(pagedResponse);
        }

        private Uri GetNextPage(TFilter filter)
        {
            TFilter nextFilter = filter.Clone() as TFilter;
            nextFilter.Page += 1;

            var query = _context.Set<TEntity>().AsQueryable();

            query = Filter(query, nextFilter);
            query = Paginate(query, nextFilter);

            var nextPageUri = query.Any() ? new Uri(GetUrlFor(nextFilter)) : null;

            return nextPageUri;
        }

        private Uri GetPreviousPage(TFilter filter)
        {
            TFilter previousFilter = filter.Clone() as TFilter;
            previousFilter.Page -= 1;

            var previousPageUri = previousFilter.Page > 0 ? new Uri(GetUrlFor(previousFilter)) : null;

            return previousPageUri;
        }

        private string GetUrlFor(TFilter filter)
        {
            return Url.Action("Get", null, filter, Request.Scheme);
        }

        protected abstract IQueryable<TEntity> Filter(IQueryable<TEntity> query, TFilter filter);

        private static IQueryable<TEntity> Paginate(IQueryable<TEntity> query, TFilter filter)
        {
            var skip = filter.Amount * (filter.Page - 1);
            var take = skip > -1 ? filter.Amount : 0;

            return query.Skip(skip).Take(take);
        }
    }
}
