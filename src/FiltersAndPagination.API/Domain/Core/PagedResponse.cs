using System;
using System.Collections.Generic;

namespace FiltersAndPagination.API.Domain.Core
{
    public class PagedResponse<T>
        where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
    }
}
