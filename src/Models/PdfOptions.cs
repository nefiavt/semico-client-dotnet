using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SemicoClient.Models
{
    public class PdfOptions
    {
        [JsonPropertyName("additionalMetadata")]
        public string AdditionalMetadata { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("producer")]
        public string Producer { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("application")]
        public string Application { get; set; }
    }
}
