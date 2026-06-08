using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.DTOs;
using Organizer.Application.Services;

namespace Organizer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _service;

    public TarefaController(ITarefaService service)
    {
        _service = service;
    }

    //TODO Criar as Rotas Necessárias

    /**
     * Forma mais moderna de retornar resultados na API
     * poderia ser IActionResult ou ActionResult,
     * mas o melhor é tipando o ActionResult
     * <T>
     */
    [HttpGet("{listaId:int}", Name = "GetTarefas")]
    public async Task<ActionResult<IEnumerable<TarefaDTO>>> GetTarefas(int listaId, [FromQuery] int page,
        [FromQuery] int skip)
    {
        var tarefas = await _service.PesquisarPaginados(listaId, page, skip);
        if (tarefas == null) return NotFound();
        return Ok(tarefas);
    }

    [HttpPut]
    public async Task<ActionResult<TarefaDTO>> PutTarefa([FromBody] TarefaDTO tarefadto)
    {
        var tarefa = await _service.Atualizar(tarefadto);
        if (tarefa == null) return NotFound();
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaDTO>> PostTarefa([FromBody] TarefaDTO tarefa)
    {
        var tarefaCriada = await _service.Adicionar(tarefa);
        if (tarefaCriada == null) return NotFound();
        return CreatedAtAction(nameof(ListaController.GetListaById), "Lista",
            new { listaId = tarefaCriada.ListaId }, tarefaCriada);
    }
}