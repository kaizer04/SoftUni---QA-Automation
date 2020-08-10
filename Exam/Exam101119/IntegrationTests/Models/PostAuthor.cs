using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IntegrationTests.Models
{
    public partial class PostAuthor
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
        
        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("age")]
        public long Age { get; set; }
    }

    public partial class PostAuthor
    {
        public static PostAuthor FromJson(string json) => JsonConvert.DeserializeObject<PostAuthor>(json, Converter.Settings);
    }

   
}
