using FileStorage.API.Model;
using FileStorage.Web.Services;
using Microsoft.AspNetCore.Components;

namespace FileStorage.Web.Pages
{
    public partial class EditFile
    {
        [Inject]
        public IFileService FileService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public UploadedFiles UploadFile { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            UploadFile = new UploadedFiles { };

            UploadFile = await FileService.GetFile(int.Parse(Id));
        }

        protected async Task HandleValidSubmit()
        {
            UploadedFiles result = await FileService.UpdateFile(UploadFile);

            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected async Task Delete_Click()
        {
            await FileService.DeleteFile(UploadFile.Id);

            NavigationManager.NavigateTo("/");
        }
    }
}