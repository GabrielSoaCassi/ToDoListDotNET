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
public class ListaController : ControllerBase
{
    private readonly IService<Lista> _listaService;
    private readonly IMapper _mapper;

    public ListaController(IService<Lista> service, IMapper mapper)
    {
        _listaService = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarLista([FromBody] CreateListaDto listaDto)
    {
        var lista = _mapper.Map<Lista>(listaDto);
        try
        {
            var result = await _listaService.Adicionar(lista);
            return CreatedAtAction(nameof(PesquisarListaPorId), new { id = result.Id }, result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ProcurarLista([FromQuery] int skip = 1, [FromQuery] int take = 5)
    {
        return Ok(await _listaService.PesquisarPaginados(skip, take));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PesquisarListaPorId(int id)
    {
        try
        {
            return Ok(await _listaService.PesquisarPorId(id));
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarLista(int id, [FromBody] Lista listaAtualizada)
    {
        try
        {
            var lista = await _listaService.Atualizar(id, listaAtualizada);
            return Ok(lista);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverLista(int id)
    {
        try
        {
            await _listaService.Remover(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}