using SemicoClient.Client;
using SemicoClient.Exceptions;
using SemicoClient.Models;
using SemicoClient.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SemicoClient.Services
{
    public class SemicoClientService : ISemicoClientService
    {
        private readonly HttpClient client;

        public string Uri { get; set; } = $"/api/v1/Semico/GenerateDocument";

        public SemicoClientService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<Stream> GenerateDocument(Stream template, Stream jsonData)
        { 
            GenerateDocumentRequest documentRequest = new GenerateDocumentRequest
            {
                Data = Converter.ConvertToBase64(jsonData),
                Template = Converter.ConvertToBase64(template)
            };

            GenerateDocumentResponse response = await RemoteCall(documentRequest);

            return Converter.ConvertToStream(response.Document);
        }

        public async Task<Stream> GenerateDocument(byte [] template, byte [] jsonData)
        {
            GenerateDocumentRequest documentRequest = new GenerateDocumentRequest
            {
                Data = Converter.ConvertToBase64(jsonData),
                Template = Converter.ConvertToBase64(template)
            };

            GenerateDocumentResponse response = await RemoteCall(documentRequest);

            return Converter.ConvertToStream(response.Document);
        }

        private async Task <GenerateDocumentResponse> RemoteCall(GenerateDocumentRequest documentRequest)
        {
            string jsonString = JsonSerializer.Serialize(documentRequest);

            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMsg = await client.PostAsync(Uri, content);

            string responseMessage = await responseMsg.Content.ReadAsStringAsync();

            if (!responseMsg.IsSuccessStatusCode)
            {
                if (responseMsg.IsJson())
                {
                    ErrorResponse errModel = JsonSerializer.Deserialize<ErrorResponse>(responseMessage);

                    responseMessage = errModel.Message;
                }

                throw new SemicoComunicationException(responseMessage);
            }

            GenerateDocumentResponse response = JsonSerializer.Deserialize<GenerateDocumentResponse>(responseMessage);

            return response;
        }
    }
}
