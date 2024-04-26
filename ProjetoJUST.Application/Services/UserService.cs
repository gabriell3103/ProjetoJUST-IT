using AutoMapper;
using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Application.DTOs.Validations;
using ProjetoJUST.Application.Services.Interfaces;
using ProjetoJUST.Domain.Entities;
using ProjetoJUST.Domain.FiltersDb;
using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository personRepository, IMapper mapper)
    {
        _userRepository = personRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<UserDTO>> CreateAsync(UserDTO userDTO)
    {
        if (userDTO == null)
            return ResultService.Fail<UserDTO>("Objeto deve ser informado");

        var result = new UserDTOValidator().Validate(userDTO);
        if(!result.IsValid)
            return ResultService.RequestError<UserDTO>("Problema de validacao!",result);

        var user = _mapper.Map<User>(userDTO);
        var data = await _userRepository.CreateAsync(user);            
        return ResultService.Ok<UserDTO>(_mapper.Map<UserDTO>(data)); 
        
    }

    public async Task<ResultService<ICollection<UserDTO>>> GetAsync()
    {
        var users = await _userRepository.GetUsersAsync();                 
        return ResultService.Ok<ICollection<UserDTO>>(_mapper.Map<ICollection<UserDTO>>(users));
    }

    public async Task<ResultService<UserDTO>> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return ResultService.Fail<UserDTO>("Pessoa não encontrada!");
        return ResultService.Ok(_mapper.Map<UserDTO>(user));
    }
    
    public async Task<ResultService> RemoveAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            return ResultService.Fail("Pessoa não encontrada!");

        await _userRepository.DeleteAsync(user);
        return ResultService.Ok($"Pessoa do id:{id} deletada");
    }

    public async Task<ResultService<PagedBaseResponseDTO<UserDTO>>> GetPaged(UserFilterDb userFilterDb)
    {
        var peoplePaged = await _userRepository.GetPagedAsync(userFilterDb);
        var result = new PagedBaseResponseDTO<UserDTO>(peoplePaged.TotalRegisters, _mapper.Map<List<UserDTO>>(peoplePaged.Data));
        return ResultService.Ok(result);
    }

    public async Task<ResultService> UpdateAsync(UserDTO userDTO)
    {
        if (userDTO == null)
            return ResultService.Fail<UserDTO>("Objeto deve ser informado");

        var validation = new UserDTOValidator().Validate(userDTO);
        if (!validation.IsValid)
            return ResultService.RequestError<UserDTO>("Problema de validacao!", validation);

        var user = await _userRepository.GetByIdAsync(userDTO.Id);
        if (user == null)
            return ResultService.Fail("Pessoa não encontrada!");

        user = _mapper.Map<UserDTO, User>(userDTO, user);            
        await _userRepository.EditAsync(user);
        return ResultService.Ok("Pessoa editada");
    }
}