using ProjetoJUST.Domain.Repositories;

namespace ProjetoJUST.Application.DTOs;

public class PagedBaseResponseDTO<T>
{
    public PagedBaseResponseDTO(int totalRegister, List<T> data)
    {
        TotalRegister = totalRegister;
        Data = data;
    }

    public int TotalRegister { get; set; }
    public List<T> Data { get; set; }
}