using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.DTOs;
using Organizer.Domain.Interfaces;

namespace Organizer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TarefaController : ControllerBase
{
    private readonly IService<TarefaDTO> _service;
    
    public TarefaController(IService<TarefaDTO> service)
    {
        _service = service;
    }
    
    //TODO Criar as Rotas Necessárias

    [HttpGet]
    public async Task<IActionResult<IEnumerable<TarefaDTO>> Get([FromQuery] int page, [FromQuery] int skip)
    {
        var tarefas = _service.PesquisarPaginados(page, skip);
    }
    
}