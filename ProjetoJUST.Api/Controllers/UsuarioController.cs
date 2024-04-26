using Microsoft.AspNetCore.Mvc;
using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Application.Services.Interfaces;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    [Route("token")]
    public async Task<ActionResult> PostAsync([FromForm] UsuarioDTO usuarioDTO)
    {
        var result = await _usuarioService.GenerateTokenAsync(usuarioDTO);
        if (result.IsSuccess)
            return Ok(result.Data);

        return BadRequest(result);
    } 
}
