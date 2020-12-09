using FiltersAndPagination.API.Domain.Core;
using System;

namespace FiltersAndPagination.API.Domain.Models
{
    public class Task : Entity
    {
        public string Description { get; set; }
        public bool IsFinished { get; set; }
        public DateTime? FinishedDate { get; set; }
        public ToDo ToDo { get; set; }
        public long ToDoId { get; set; }
    }
}
