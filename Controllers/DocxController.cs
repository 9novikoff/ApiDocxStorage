using DocxStorageApi.BLL;
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
            await _docxService.SaveDocxAsync(email, file);
            return Ok();
        }
    }
}
