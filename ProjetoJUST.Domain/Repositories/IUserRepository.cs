using ProjetoJUST.Domain.Entities;
using ProjetoJUST.Domain.FiltersDb;

namespace ProjetoJUST.Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<ICollection<User>> GetUsersAsync();
    Task<User> CreateAsync(User user);
    Task EditAsync(User user);
    Task DeleteAsync(User user);
    Task<int> GetIdByEmailAsync(string email);
    Task<PagedBaseResponse<User>> GetPagedAsync(UserFilterDb request);

}