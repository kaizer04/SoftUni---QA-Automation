namespace IntegrationTests
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public object FirstName { get; set; }

        [JsonProperty("lastName")]
        public object LastName { get; set; }

        [JsonProperty("wishlistId")]
        public long WishlistId { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("householdId")]
        public object HouseholdId { get; set; }
    }

    public partial class User
    {
        public static User FromJson(string json) => JsonConvert.DeserializeObject<User>(json, IntegrationTests.ConverterUsers.Settings);

        public static List<User> ListFromJson(string json) => JsonConvert.DeserializeObject<List<User>>(json, IntegrationTests.ConverterUsers.Settings);
    }

    public static class SerializeUser
    {
        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, IntegrationTests.ConverterUsers.Settings);
    }

    internal static class ConverterUsers
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}