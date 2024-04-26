using Microsoft.EntityFrameworkCore;
using ProjetoJUST.Domain.Entities;
using ProjetoJUST.Domain.Repositories;
using ProjetoJUST.Infra.Data.Context;

namespace ProjetoJUST.Infra.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _db;

    public UsuarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Usuario?> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _db.Usuarios.Include(x => x.UsuarioPermissions).ThenInclude(x => x.Permission)
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
    }
}