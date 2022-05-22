using AutoMapper;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Profiles
{
    public class ListaProfile:Profile
    {
        public ListaProfile()
        {
            CreateMap<CreateListaDto, Lista>();
        }
    }
}
