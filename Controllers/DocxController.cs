using DocxStorageApi.BLL;
using DocxStorageApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocxStorageApi.Controllers
{
    [Route("api")]
    public class DocxController : ControllerBase
    {
        private readonly DocxService _docxService;

        public DocxController(DocxService docxService)
        {
            _docxService = docxService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string email, [FromForm] IFormFile file)
        {
	        var signedFile = new SignedFile() { Email = email, File = file, FileName = file.FileName};

	        if (!TryValidateModel(signedFile))
	        {
		        return BadRequest();
	        }

			await _docxService.SaveDocxAsync(signedFile);
            return Ok();
        }
    }
}
