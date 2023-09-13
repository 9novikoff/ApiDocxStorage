using Azure.Storage.Blobs.Models;
using DocxStorageApi.DAL;
using DocxStorageApi.Models;

namespace DocxStorageApi.BLL
{
    public class DocxService
    {
        private readonly IDocxRepository _docxRepository;

        public DocxService(IDocxRepository docxRepository)
        {
            _docxRepository = docxRepository;
        }

        public async Task SaveDocxAsync(string email, IFormFile file)
        {
            var signedFile = new SignedFile() { Email = email, File = file };

            await _docxRepository.UploadDocxAsync(signedFile);
        }
    }
}
