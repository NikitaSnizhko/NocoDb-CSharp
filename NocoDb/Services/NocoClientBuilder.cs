using System;
using System.Net.Http;

namespace NocoDb.Services
{
    public class NocoClientBuilder
    {
        private readonly NocoClientOptions _nocoClientOptions;
        private static readonly HttpClient HttpClient;

        static NocoClientBuilder()
        {
            HttpClient = new HttpClient();
        }

        public NocoClientBuilder(NocoClientOptions nocoClientOptions)
        {
            _nocoClientOptions = nocoClientOptions;
            HttpClient.DefaultRequestHeaders.Add("xc-token", _nocoClientOptions.NocoApiKey);
            HttpClient.BaseAddress = new Uri(_nocoClientOptions.NocoBaseUrl);
        }

        public NocoClient Build()
        {
            return new NocoClient(HttpClient);
        }
    }
}