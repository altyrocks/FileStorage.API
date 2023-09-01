using FileStorage.API.Model;
using Microsoft.EntityFrameworkCore;

namespace FileStorage.API.Repository
{
    public class FileRepository : IFileRepository
    {
        private readonly AppDbContext appDbContext;

        public FileRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Model.UploadedFiles>> GetAllFiles()
        {
            return await appDbContext.UploadedFiles.ToListAsync();
        }

        public async Task<Model.UploadedFiles> GetFile(int Id)
        {
            return await appDbContext.UploadedFiles.FirstOrDefaultAsync(e => e.Id == Id);
        }

        public async Task<Model.UploadedFiles> AddFile(Model.UploadedFiles employee)
        {
            var result = await appDbContext.UploadedFiles.AddAsync(employee);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Model.UploadedFiles> UpdateFile(Model.UploadedFiles file)
        {
            var result = await appDbContext.UploadedFiles.FirstOrDefaultAsync(e => e.Id == file.Id);

            if (result != null)
            {
                result.FileVersion = file.FileVersion;
                result.FileName = file.FileName;
                result.FileData = file.FileData;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Model.UploadedFiles> DeleteFile(int Id)
        {
            var result = await appDbContext.UploadedFiles.FirstOrDefaultAsync(e => e.Id == Id);

            if (result != null)
            {
                appDbContext.UploadedFiles.Remove(result);

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}