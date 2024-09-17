using System;
using System.Net.Http;

namespace NocoDb.Services
{
    public partial class NocoClient(HttpClient httpClient) : IDisposable
    {
        private bool _disposed;

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
                httpClient?.Dispose();
            }

            _disposed = true;
        }

        ~NocoClient()
        {
            Dispose(false);
        }
    }
}