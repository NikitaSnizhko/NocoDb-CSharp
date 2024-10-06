using System.Net.Http;
using System.Threading.Tasks;

namespace NocoDb.Extensions;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> PatchAsync(
        this HttpClient client, 
        string requestUri, 
        HttpContent content)
    {
        var request = new HttpRequestMessage(new HttpMethod("PATCH"), requestUri)
        {
            Content = content
        };
        return await client.SendAsync(request);
    }
    
    public static async Task<HttpResponseMessage> DeleteAsync(
        this HttpClient client, 
        string requestUri, 
        HttpContent content)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, requestUri)
        {
            Content = content
        };
        return await client.SendAsync(request);
    }
}