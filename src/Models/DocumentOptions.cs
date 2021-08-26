using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SemicoClient.Models
{
    public class DocumentOptions
    {
        [JsonPropertyName("convertToPdf")]
        public bool ConvertToPdf { get; set; } = false;

        [JsonPropertyName("pdfOptions")]
        public PdfOptions PdfOptions { get; set; }
    }
}
