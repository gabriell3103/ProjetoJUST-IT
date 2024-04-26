using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Application.Services.Interfaces;
using ProjetoJUST.Domain.Authentication;
using ProjetoJUST.Domain.Entities;
using ProjetoJUST.Domain.FiltersDb;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private List<string> _permissionNeeded = new List<string>() { "Admin" };
    private readonly ICurrentUsuario _currentUsuario;
    private readonly List<string> _permissionUsuario;

    public UserController(IUserService userService, ICurrentUsuario currentUsuario)
    {
        _userService = userService;
        _currentUsuario = currentUsuario;
        _permissionUsuario = _currentUsuario.Permissions.Split(",").ToList();
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserDTO userDTO)
    {
        _permissionNeeded.Add("CadastraPessoa");
        if (!ValidPermission(_permissionUsuario, _permissionNeeded))
            return Forbidden();

        var result = await _userService.CreateAsync(userDTO);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        _permissionNeeded.Add("BuscaPessoa");
        if (!ValidPermission(_permissionUsuario, _permissionNeeded))
            return Forbidden();

        var result = await _userService.GetAsync();
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [Route("paged")]
    public async Task<IActionResult> GetPagedAsync([FromQuery] UserFilterDb pageRequest)
    {
        _permissionNeeded.Add("BuscaPessoa");
        if (!ValidPermission(_permissionUsuario, _permissionNeeded))
            return Forbidden();

        var result = await _userService.GetPaged(pageRequest);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetIdAsync(int id)
    {
        _permissionNeeded.Add("BuscaPessoa");
        if (!ValidPermission(_permissionUsuario, _permissionNeeded))
            return Forbidden();

        var result = await _userService.GetByIdAsync(id);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UserDTO userDTO)
    {
        _permissionNeeded.Add("EditaPessoa");
        if (!ValidPermission(_permissionUsuario, _permissionNeeded))
            return Forbidden();

        var result = await _userService.UpdateAsync(userDTO);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        _permissionNeeded.Add("DeletaPessoa");

if(!ValidPermission(_permissionUsuario,_permissionNeeded))
            return Forbidden();

        var result = await _userService.RemoveAsync(id);
        if (result.IsSuccess)
            return Ok(result);
        return BadRequest(result);
    }
}