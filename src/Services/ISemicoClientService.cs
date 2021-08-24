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
        Task<Stream> GenerateDocument(Stream template, Stream jsonData);
        Task<Stream> GenerateDocument(byte[] template, byte[] jsonData);
    }
}
