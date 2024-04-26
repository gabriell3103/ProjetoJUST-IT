using Microsoft.EntityFrameworkCore;
using ProjetoJUST.Domain.Entities;
using ProjetoJUST.Domain.FiltersDb;
using ProjetoJUST.Domain.Repositories;
using ProjetoJUST.Infra.Data.Context;

namespace ProjetoJUST.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{

    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User> CreateAsync(User user)
    {
        _db.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task DeleteAsync(User user)
    {
        _db.Remove(user); 
        await _db.SaveChangesAsync();
    }

    public async Task<int> GetIdByEmailAsync(string email)
    {
        return (await _db.Users.FirstOrDefaultAsync(x => x.Email == email))?.Id ?? 0;
    }


    public async Task<PagedBaseResponse<User>> GetPagedAsync(UserFilterDb request)
    {
        var users = _db.Users.AsQueryable();
        if (!string.IsNullOrEmpty(request.Name))
            users = users.Where(x => x.Name.Contains(request.Name));

        return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<User>,User>(users, request);
    }

    public async Task EditAsync(User user)
    {
        _db.Update(user); 
        await _db.SaveChangesAsync();
    }

    public async Task<ICollection<User>> GetUsersAsync()
    {
        return await _db.Users.ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
}