using AutoMapper;
using ProjetoJUST.Application.DTOs;
using ProjetoJUST.Domain.Entities;

namespace ProjetoJUST.Application.Mappings;

public class DomainToDtoMappings : Profile
{
    public DomainToDtoMappings()
    {
        CreateMap<User, UserDTO>();
    }
}