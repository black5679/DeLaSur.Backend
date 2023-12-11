using Azure.Storage.Blobs;
using DeLaSur.Backend.Domain.Services;
using Microsoft.AspNetCore.Http;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient blobServiceClient;
        public StorageService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
        public async Task Upload(IFormFile file, string container, string? fileName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(container);
            await containerClient.CreateIfNotExistsAsync();
            var blobClient = containerClient.GetBlobClient(fileName ?? file.FileName);
            using Stream fileStream = file.OpenReadStream();
            await blobClient.UploadAsync(fileStream, true);
        }
    }
}
