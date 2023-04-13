using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Yugen.MotoGP.App.Models.Results.Classification
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class ClassificationBase
    {
        [JsonPropertyName("classification")]
        public List<Classification> Classification { get; set; }

        //[JsonPropertyName("records")]
        //public List<Record> Records { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }
    }
}