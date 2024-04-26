using AutoMapper;
using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Application.Mappings;

public class DtoToDomainMappins : Profile
{
    public DtoToDomainMappins()
    {
        CreateMap<UserDTO, User>();
    }
}