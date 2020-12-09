using FiltersAndPagination.API.Domain.Core;
using System.Collections.Generic;

namespace FiltersAndPagination.API.Domain.Models
{
    public class ToDo : Entity
    {
        public string Name { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
