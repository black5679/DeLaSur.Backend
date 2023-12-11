using Microsoft.AspNetCore.Http;

namespace DeLaSur.Backend.Domain.Services
{
    public interface IStorageService
    {
        Task Upload(IFormFile file, string container, string fileName);
    }
}
