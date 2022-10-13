using APIFibra.Entities;

namespace APIFibra.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Administrativo user);
    }
}