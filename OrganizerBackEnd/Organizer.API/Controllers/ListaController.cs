using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.DTOs;
using Organizer.Domain.Interfaces;

namespace Organizer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ListaController : ControllerBase
{
    private readonly IService<ListaDTO> _service;
    
    public ListaController(IService<ListaDTO> service)
    {
        _service = service;
    }
    //TODO Criar as Rotas Necessárias
}