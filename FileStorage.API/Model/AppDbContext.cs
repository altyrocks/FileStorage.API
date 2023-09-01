using Microsoft.EntityFrameworkCore;

namespace FileStorage.API.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UploadedFiles>? UploadedFiles { get; set; }
    }
}