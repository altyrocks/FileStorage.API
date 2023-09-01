using FileStorage.API.Model;
using System.Net.Http.Json;

namespace FileStorage.Web.Services
{
    public class FileService : IFileService
    {
        private readonly HttpClient httpClient;

        public FileService(HttpClient httpClient) 
        { 
            this.httpClient = httpClient;
        }

        public async Task<UploadedFiles> GetFile(int id)
        {
            return await httpClient.GetFromJsonAsync<UploadedFiles>($"api/controller/{id}");
        }

        public async Task<IEnumerable<UploadedFiles>> GetAllFiles()
        {
            return await httpClient.GetFromJsonAsync<UploadedFiles[]>("api/controller");
        }

        public async Task<UploadedFiles> CreateFile(UploadedFiles createFile)
        {
            var response = await httpClient.PostAsJsonAsync($"api/controller", createFile);

            return await response.Content.ReadFromJsonAsync<UploadedFiles>();
        }

        public async Task<UploadedFiles> UpdateFile(UploadedFiles updateFile)
        {
            var response = await httpClient.PutAsJsonAsync("api/controller", updateFile);

            return await response.Content.ReadFromJsonAsync<UploadedFiles>();
        }

        public async Task DeleteFile(int id)
        {
            await httpClient.DeleteAsync($"api/controller/{id}");
        }
    }
}