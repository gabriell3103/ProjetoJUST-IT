using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Domain.Authentication;

public interface ITokenGenerator
{
    dynamic Generator(Usuario usuario);
}