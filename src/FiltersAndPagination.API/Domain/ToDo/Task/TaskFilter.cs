using FiltersAndPagination.API.Domain.Core;
using System;

namespace FiltersAndPagination.API.Domain
{
    public class TaskFilter : Filter
    {
        public string Description { get; set; }
        public bool? IsFinished { get; set; }
        public DateTime? FinishedDate { get; set; }
        public long? ToDoId { get; set; }
    }
}
