using ProjetoJUST.Domain.Validations;

namespace ProjetoJUST.Domain.Entities;

public sealed class UsuarioPermission
{
    public UsuarioPermission(int usuarioId, int permissionId)
    {
        Validation(usuarioId,permissionId);
    }

    public int Id { get; private set; }
    public int UsuarioId { get; private set; }
    public int PermissionId { get; private set; }

    public Usuario Usuario {get; set;}
    public Permission Permission {get; set;}


    private void Validation(int usuarioId, int permissionId)
    {
        DomainValidationException.When(usuarioId == 0, "Id usuário deve ser informado");            
        DomainValidationException.When(permissionId == 0, "Id permissão deve ser informado");            

        UsuarioId = usuarioId;
        PermissionId = permissionId;
    }
}