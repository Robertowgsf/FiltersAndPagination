using FiltersAndPagination.API.Domain.Core;
using FiltersAndPagination.API.Domain.Models;
using FiltersAndPagination.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FiltersAndPagination.API.Domain
{
    [Route("to-do")]
    public class ToDoController : QueryController<ToDo, ToDoFilter>
    {
        public ToDoController(FiltersAndPaginationContext context)
            : base(context) { }

        protected override IQueryable<ToDo> Filter(IQueryable<ToDo> query, ToDoFilter filter)
        {
            if (filter.Name != null)
            {
                query = query.Where(toDo => toDo.Name.ToUpperInvariant().Contains(filter.Name.ToUpperInvariant()));
            }

            return query;
        }
    }
}
