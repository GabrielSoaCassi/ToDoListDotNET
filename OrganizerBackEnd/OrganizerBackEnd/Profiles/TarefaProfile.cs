using AutoMapper;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Profiles;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<CreateTarefaDto, Tarefa>();
    }
}