using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests.Models
{
    public static class Serialize
    {
        public static string ToJson(this Author self) => JsonConvert.SerializeObject(self, IntegrationTests.Models.Converter.Settings);

        public static string ToJson(this PostAuthor self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
