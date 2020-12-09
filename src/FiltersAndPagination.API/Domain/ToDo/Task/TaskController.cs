using FiltersAndPagination.API.Domain.Core;
using FiltersAndPagination.API.Domain.Models;
using FiltersAndPagination.API.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FiltersAndPagination.API.Domain
{
    [Route("task")]
    public class TaskController : QueryController<Task, TaskFilter>
    {
        public TaskController(FiltersAndPaginationContext context)
            : base(context) { }

        protected override IQueryable<Task> Filter(IQueryable<Task> query, TaskFilter filter)
        {
            if (filter.IsFinished.HasValue)
            {
                query = query.Where(task => task.IsFinished == filter.IsFinished);
            }

            if (filter.Description != null)
            {
                query = query.Where(task => task.Description.ToUpperInvariant().Contains(filter.Description.ToUpperInvariant()));
            }

            if (filter.FinishedDate != null)
            {
                query = query.Where(task => task.FinishedDate == filter.FinishedDate);
            }

            if (filter.ToDoId != null)
            {
                query = query.Where(task => task.ToDoId == filter.ToDoId);
            }

            return query;
        }
    }
}
