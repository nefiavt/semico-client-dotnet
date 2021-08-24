using Microsoft.Extensions.DependencyInjection;
using SemicoClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemicoClient.Client
{
    public static class ServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddExternalTaskClient(this IServiceCollection services)
        {
            return services.AddHttpClient<ISemicoClientService, SemicoClientService>();
        }
    }
}
