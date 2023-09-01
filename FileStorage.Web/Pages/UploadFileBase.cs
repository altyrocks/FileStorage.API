using FileStorage.API.Model;
using FileStorage.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace FileStorage.Web.Pages
{
    public class UploadFileBase : ComponentBase
    {
        [Inject]
        public IFileService FileService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UploadedFiles UploadFile { get; set; }

        public List<string> errors = new();

        protected override async Task OnInitializedAsync()
        {
            UploadFile = new UploadedFiles
            {
                FileName = string.Empty,
                FileData = null,
                FileVersion = 1
            };
        }

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {
            errors.Clear();
            var counter = 1;

            MemoryStream ms = new MemoryStream();

            await e.File.OpenReadStream().CopyToAsync(ms);

            UploadFile.FileData = ms.ToArray();
            UploadFile.FileName = e.File.Name;

            var AllFiles = (await FileService.GetAllFiles()).ToList();

            foreach (var file in AllFiles) 
            { 
                if (file.FileName == UploadFile.FileName)
                {
                    counter++;
                }
            }

            UploadFile.FileVersion = counter;

            UploadedFiles result = await FileService.CreateFile(UploadFile);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}