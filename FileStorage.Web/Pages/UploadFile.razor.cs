using FileStorage.API.Model;
using FileStorage.Web.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace FileStorage.Web.Pages
{
    public partial class UploadFile
    {
        [Inject]
        public IFileService FileService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UploadedFiles UploadFiles { get; set; }

        public List<string> errors = new();

        protected override Task OnInitializedAsync()
        {
            UploadFiles = new UploadedFiles
            {
                FileName = string.Empty,
                FileData = null,
                FileVersion = 1
            };

            return Task.CompletedTask;
        }

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {
            errors.Clear();

            var counter = 1;

            MemoryStream ms = new();

            await e.File.OpenReadStream().CopyToAsync(ms);

            UploadFiles.FileData = ms.ToArray();
            UploadFiles.FileName = e.File.Name;

            var AllFiles = (await FileService.GetAllFiles()).ToList();

            foreach (var file in AllFiles)
            {
                if (file.FileName == UploadFiles.FileName)
                {
                    counter++;
                }
            }

            UploadFiles.FileVersion = counter;

            UploadedFiles result = await FileService.CreateFile(UploadFiles);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}