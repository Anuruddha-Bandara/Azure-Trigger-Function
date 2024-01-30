using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggerFun.Model
{
    public class Book : Entity
    {
        [JsonProperty(PropertyName = "category", Required = Required.Always)]
        public string category { get; set; } = "novels";

        [JsonProperty(PropertyName = "title", Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", Required = Required.Always)]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }

        [JsonProperty(PropertyName = "publisher")]
        public string Publisher { get; set; }

        [JsonProperty(PropertyName = "authors", Required = Required.Always)]
        public IEnumerable<Author> Authors { get; set; }
    }

    public class Author
    {
        [JsonProperty(PropertyName = "firstName", Required = Required.Always)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName", Required = Required.Always)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
