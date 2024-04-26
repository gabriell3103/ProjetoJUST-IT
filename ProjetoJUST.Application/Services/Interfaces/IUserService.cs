using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Domain.FiltersDb;
using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Application.Services.Interfaces;

public interface IUserService
{
    Task<ResultService<UserDTO>> CreateAsync(UserDTO userDTO);
    Task<ResultService<ICollection<UserDTO>>> GetAsync();
    Task<ResultService<UserDTO>> GetByIdAsync(int id);
    Task<ResultService> UpdateAsync(UserDTO userDTO);
    Task<ResultService> RemoveAsync(int id);
    Task<ResultService<PagedBaseResponseDTO<UserDTO>>> GetPaged(UserFilterDb pageRequestDTO);
}