using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SemicoClient.Client
{
    internal static class HttpClientExtensions
    {
        private const string JsonContentType = "application/json";

        internal static bool IsJson(this HttpContentHeaders headers) =>
            headers?.ContentType?.MediaType == JsonContentType;

        internal static bool IsJson(this HttpResponseMessage message) =>
            message.Content?.Headers?.IsJson() ?? false;
    }
}
