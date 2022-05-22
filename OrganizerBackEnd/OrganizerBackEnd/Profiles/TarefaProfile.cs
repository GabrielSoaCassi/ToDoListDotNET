using AutoMapper;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizerBackEnd.Profiles
{
    public class TarefaProfile :Profile
    {
        public TarefaProfile()
        {
            CreateMap<CreateTarefaDto, Tarefa>();
        }
    }
}
