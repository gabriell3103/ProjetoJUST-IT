using ProjetoJUST.Application.DTOs;

namespace ProjetoJUST.Application.Services.Interfaces;

public interface IUsuarioService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UsuarioDTO usuarioDTO);
}