using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SemicoClient.Models
{
    public class GenerateDocumentRequest
    {
        [JsonPropertyName("template")]
        [Required]
        /// <summary>
        /// Base64 representation of DOCX template
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Base64 representation of JSON data 
        /// </summary>
        [JsonPropertyName("data")]
        [Required]
        public string Data { get; set; }
    }
}
