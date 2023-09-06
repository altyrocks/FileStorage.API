namespace FileStorage.API.Model
{
    public class UploadedFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileData { get; set; }
        public int FileVersion { get; set; }
    }
}