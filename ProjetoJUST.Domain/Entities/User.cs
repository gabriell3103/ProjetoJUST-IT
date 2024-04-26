using ProjetoJUST.Domain.Validations;

namespace ProjetoJUST.Domain.Entities;

public sealed class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    public User(string name, string email, string password)
    {
        Validation(name, email, password);
    }

    public User(int id,string name, string email, string password)
    {
        DomainValidationException.When(id < 0, "Id invalido");
        Id = id;
        Validation(name, email, password);
    }

    private void Validation(string name, string email, string password)
    {
        DomainValidationException.When(string.IsNullOrEmpty(name), "Nome deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(email), "Email deve ser informado!");
        DomainValidationException.When(string.IsNullOrEmpty(password), "Senha deve ser informado!");

        Name = name;
        Email = email;
        Password = password;
    }
}