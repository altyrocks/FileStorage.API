using FileStorage.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.API.Repository
{
    public interface IFileRepository
    {
        Task<IEnumerable<Model.UploadedFiles>> GetAllFiles();
        Task<Model.UploadedFiles> GetFile(int Id);
        Task<Model.UploadedFiles> AddFile(Model.UploadedFiles uploadedFile);
        Task<Model.UploadedFiles> UpdateFile(Model.UploadedFiles uploadedFile);
        Task<Model.UploadedFiles> DeleteFile(int Id);
    }
}