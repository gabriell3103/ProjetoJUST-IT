using ProjetoJUST.Domain.Validations;

namespace ProjetoJUST.Domain.Entities;

public class Usuario
{
    public Usuario(string email, string password)
    {
        Validation(email, password);
        UsuarioPermissions = new List<UsuarioPermission>();
    }

    public Usuario(int id, string email, string password)
    {            
        DomainValidationException.When(id < 0, "Id deve ser informado!");
        Id = id;
        Validation(email, password);
        UsuarioPermissions = new List<UsuarioPermission>(); 
    }

    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public ICollection<UsuarioPermission> UsuarioPermissions { get; set; }

    private void Validation(string email, string password)
    {
        DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(password), "Senha deve ser informado!");            
        Email = email;
        Password = password;            
    }
}