using Newtonsoft.Json;
using System;

namespace FiltersAndPagination.API.Domain.Core
{
    public abstract class Filter : ICloneable
    {
        public int Page { get; set; }
        public int Amount { get; set; }
        public string[] Includes { get; set; }

        public Filter()
        {
            Page = 1;
            Amount = 10;
        }

        public object Clone()
        {
            var jsonString = JsonConvert.SerializeObject(this);

            return JsonConvert.DeserializeObject(jsonString, GetType());
        }
    }
}
