using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Domain.FiltersDb;

public class UserFilterDb : PagedBaseRequest
{
    public string? Name { get; set; }
}