using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Domain.Repositories;

public interface IUsuarioRepository
{
    Task<Usuario?> GetUserByEmailAndPasswordAsync(string email, string password);
}