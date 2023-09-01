using FileStorage.API.Repository;
using FileStorage.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace FileStorage.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFiles()
        {
            try
            {
                return Ok(await fileRepository.GetAllFiles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UploadedFiles>> GetFile(int id)
        {
            try
            {
                var result = await fileRepository.GetFile(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UploadedFiles>> AddFile(UploadedFiles file)
        {
            try
            {
                if (file == null)
                {
                    return BadRequest();
                }

                var createdFile = await fileRepository.AddFile(file);

                return CreatedAtAction(nameof(GetFile), new { id = createdFile.Id }, createdFile);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new employee record");
            }
        }

        [HttpPut()]
        public async Task<ActionResult<UploadedFiles>> UpdateFile(UploadedFiles file)
        {
            try
            {
                var fileToUpdate = await fileRepository.GetFile(file.Id);

                if (fileToUpdate == null)
                {
                    return NotFound($"Employee with Id = {file.Id} not found");
                }

                return await fileRepository.UpdateFile(file);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Model.UploadedFiles>> DeleteFile(int id)
        {
            try
            {
                var fileToDelete = await fileRepository.GetFile(id);

                if (fileToDelete == null)
                {
                    return NotFound($"File with Id = {id} not found");
                }
                else
                {
                    return await fileRepository.DeleteFile(id);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}