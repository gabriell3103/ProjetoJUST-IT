using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Application.DTOs.Validations;
using ProjetoJUST.Application.Services.Interfaces;
using ProjetoJUST.Domain.Authentication;
using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Application.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITokenGenerator _tokenGenerator;
    
    public UsuarioService(IUsuarioRepository usuarioRepository, ITokenGenerator tokenGenerator)
    {
        _usuarioRepository = usuarioRepository;
        _tokenGenerator = tokenGenerator;
    }
    
    public async Task<ResultService<dynamic>> GenerateTokenAsync(UsuarioDTO usuarioDTO)
    {
        if (usuarioDTO == null)
            return ResultService.Fail<dynamic>("Objeto deve ser informado");

        var result = new UsuarioDTOValidator().Validate(usuarioDTO);
        if (!result.IsValid)
            return ResultService.RequestError<dynamic>("Problema de validacao!", result);

        var usuario = await _usuarioRepository.GetUserByEmailAndPasswordAsync(usuarioDTO.Email, usuarioDTO.Password);
        if(usuario == null)
            return ResultService.Fail<dynamic>("Usuário ou senha não encontrado!");

        return ResultService.Ok(_tokenGenerator.Generator(usuario));
    }
}