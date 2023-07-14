using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEyeMedHttpClient (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("EyeMed", httpClient =>
            {
                httpClient.BaseAddress = new Uri(configuration["ThirdPartyApis:EyeMedUrl"]!);
            });
        }
    }
}
