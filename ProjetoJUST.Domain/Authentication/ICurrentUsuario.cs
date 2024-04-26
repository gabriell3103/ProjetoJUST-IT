namespace ProjetoJUST.Domain.Authentication;

public interface ICurrentUsuario
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Permissions { get; set; }
}