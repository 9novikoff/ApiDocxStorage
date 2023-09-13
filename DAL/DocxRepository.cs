using System.Runtime.CompilerServices;
using Azure.Storage.Blobs;
using DocxStorageApi.Models;

namespace DocxStorageApi.DAL
{
    public interface IDocxRepository
    {
        public Task UploadDocxAsync(SignedFile signedFile);
    }
    public class DocxRepository : IDocxRepository
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;

        public DocxRepository(BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }

        public async Task UploadDocxAsync(SignedFile signedFile)
        {
            var metadata = new Dictionary<string, string>() { { "email", signedFile.Email } };

            var blobContainer = _blobServiceClient.GetBlobContainerClient(_configuration["BlobStorageContainerName"]);
            var blobClient = blobContainer.GetBlobClient(signedFile.File.FileName);

            await using Stream stream = signedFile.File.OpenReadStream();
            await blobClient.UploadAsync(stream, null, metadata);
        }
    }
}
