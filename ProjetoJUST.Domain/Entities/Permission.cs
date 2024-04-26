using ProjetoJUST.Domain.Validations;

namespace ProjetoJUST.Domain.Entities;

public sealed class Permission
{
    public Permission(string visualName, string permissionName)
    {
        Validation(visualName,permissionName);
        UsuarioPermissions = new List<UsuarioPermission>();
    }

    public int Id { get; private set; }
    public string VisualName { get; private set; }
    public string PermissionName { get; private set; }
    public ICollection<UsuarioPermission> UsuarioPermissions { get; set; }

    private void Validation(string visualName, string permissionName)
    {
        DomainValidationException.When(string.IsNullOrEmpty(visualName), "Nome visual deve ser informado");
        DomainValidationException.When(string.IsNullOrEmpty(permissionName), "Nome permissão deve ser informado");            

        VisualName = visualName;
        PermissionName = permissionName;
    }
}