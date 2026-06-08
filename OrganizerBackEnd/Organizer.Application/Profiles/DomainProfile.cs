using AutoMapper;
using Organizer.Application.DTOs;
using Organizer.Domain.Models;

namespace Organizer.Application.Profiles;

public class DomainProfile : Profile
{
    public DomainProfile()
    {
        CreateMap<ListaDTO, Lista>().ReverseMap();
        CreateMap<TarefaDTO, Tarefa>().ReverseMap();
    }
}