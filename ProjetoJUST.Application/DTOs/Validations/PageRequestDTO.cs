using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Application.DTOs.Validations;

public class PageRequestDTO<T> : PagedBaseRequest
{
    public T Filter { get; set; }
}