using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SemicoClient.Models
{
    public class GenerateDocumentResponse
    {
        /// <summary>
        /// Base64 representation of DOCX document
        /// </summary>
        [JsonPropertyName("document")]
        public string Document { get; set; }
    }
}
