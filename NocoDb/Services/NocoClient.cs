using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NocoDb.Utils;
using System.Text.Json;
using JetBrains.Annotations;
using Newtonsoft.Json;
using NocoDb.Models.Bases.Response;
using NocoDb.Models.GeneralNocoUtils;
using NocoDb.Models.GeneralNocoUtils.Dto;
using NocoDb.Models.GeneralNocoUtils.Response;
using NocoDb.Models.GeneralNocoUtils.Request;
using NocoDb.Models.Records.Dto;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace NocoDb.Services
{
    public partial class NocoClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed;
        
        public NocoClient( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _httpClient?.Dispose();
            }

            _disposed = true;
        }

        ~NocoClient()
        {
            Dispose(false);
        }
    }
}