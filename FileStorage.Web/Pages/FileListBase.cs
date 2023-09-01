using FileStorage.API.Model;
using FileStorage.Web.Services;
using Microsoft.AspNetCore.Components;

namespace FileStorage.Web.Pages
{
    public class FileListBase : ComponentBase
    {
        [Inject]
        public IFileService FileService { get; set; }   

        public IEnumerable<UploadedFiles> AllFiles { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllFiles = (await FileService.GetAllFiles()).ToList();
        }
    }
}