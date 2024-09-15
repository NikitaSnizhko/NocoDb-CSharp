using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NocoDb.Utils
{
    public static class FileOperations
    {
         /// <summary>
        /// Downloads a file from a given nocoDownloadPath and saves it to a local path.
        /// </summary>
        /// <param name="nocoDownloadPath">Path that NocoDb return to download from storage.</param>
        /// <param name="localLoadPath">Path to local folder where to save file.</param>
        /// <param name="client">HTTP client to interact with calls.</param>
        /// <exception cref="Exception">Through if client could not download file from nocoSignedPath.</exception>
        public static async Task DownloadFile(string nocoDownloadPath, string localLoadPath, HttpClient client)
        {
            var response = await client.GetAsync(nocoDownloadPath);
            if(!response.IsSuccessStatusCode)
                throw new Exception($"Failed to download file. Status code: {response.StatusCode}");
            
            using (var streamToReadFrom = await response.Content.ReadAsStreamAsync())
            {
                using (Stream streamToWriteTo = File.Open(localLoadPath, FileMode.Create))
                {
                    await streamToReadFrom.CopyToAsync(streamToWriteTo);
                }
            }
        }

        /// <summary>
        /// Uploads a file from a local path to NocoDb storage.
        /// </summary>
        /// <param name="localFilePath">Path to the file in local folder with file extension.</param>
        /// <param name="client">HTTP client to interact with calls.</param>
        /// <returns>File content as the string.</returns>
        /// <exception cref="Exception">Through if client failed to load file to the nocoDbStorage.</exception>
        public static async Task<string> UploadFile(string localFilePath, HttpClient client)
        {
            var fileContent = new ByteArrayContent(File.ReadAllBytes(localFilePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(MediaTypes.MultipartFormData);
            var fileName = Path.GetFileName(localFilePath);
            var formData = new MultipartFormDataContent
            {
                { fileContent, "file", fileName }
            };
            
            const string url = StorageUrlConstants.StorageUrl;
            var responseUpload = await client.PostAsync(url, formData);
            
            if (!responseUpload.IsSuccessStatusCode)
                throw new Exception($"Failed to upload file. Status code: {responseUpload.StatusCode}");
            
            return await responseUpload.Content.ReadAsStringAsync();
        }
    }
}