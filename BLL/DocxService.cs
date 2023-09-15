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

        public async Task SaveDocxAsync(SignedFile signedFile)
        {
	        await _docxRepository.UploadDocxAsync(signedFile);
        }
    }
}
