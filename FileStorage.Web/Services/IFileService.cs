using FileStorage.API.Model;

namespace FileStorage.Web.Services
{
    public interface IFileService
    {
        Task<UploadedFiles> GetFile(int id);
        Task<IEnumerable<UploadedFiles>> GetAllFiles();
        Task<UploadedFiles> CreateFile(UploadedFiles createFile);
        Task<UploadedFiles> UpdateFile(UploadedFiles updateFile);
        Task DeleteFile(int id);
    }
}