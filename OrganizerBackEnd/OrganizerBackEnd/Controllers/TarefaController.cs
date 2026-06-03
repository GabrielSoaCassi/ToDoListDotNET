using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Models;
using OrganizerBackEnd.Services;

namespace OrganizerBackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IService<Tarefa> _serviceTarefa;

    public TarefaController(IService<Tarefa> service, IMapper mapper)
    {
        _serviceTarefa = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarTarefa([FromBody] CreateTarefaDto tarefaDto)
    {
        var tarefa = _mapper.Map<Tarefa>(tarefaDto);
        try
        {
            await _serviceTarefa.Adicionar(tarefa);
            return CreatedAtAction(nameof(PesquisarTarefaPorId), new { id = tarefa.Id }, tarefa);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ProcurarTarefa([FromQuery] int skip = 1, [FromQuery] int take = 5)
    {
        return Ok(await _serviceTarefa.PesquisarPaginados(skip, take));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PesquisarTarefaPorId(int id)
    {
        try
        {
            return Ok(await _serviceTarefa.PesquisarPorId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
    {
        try
        {
            var resultado = await _serviceTarefa.Atualizar(id, tarefaAtualizada);
            return Ok(resultado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverTarefa(int id)
    {
        try
        {
            await _serviceTarefa.Remover(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}