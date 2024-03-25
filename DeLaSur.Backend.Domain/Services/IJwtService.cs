

namespace DeLaSur.Backend.Domain.Services
{
    public interface IJwtService
    {
        string GenerateToken(int idUsuario);
        int? ValidateToken(string token);
        string EncryptString(string plainText);
        string DecryptString(string cipherText);
    }
}
