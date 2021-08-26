using SemicoClient.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemicoClient.Services
{
    public interface ISemicoClientService
    {
        Task<MemoryStream> GenerateDocument(Stream template, Stream jsonData, DocumentOptions options = null);
        Task<MemoryStream> GenerateDocument(byte[] template, byte[] jsonData, DocumentOptions options = null);
    }
}
