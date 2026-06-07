using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.Application.DTOs;
using Organizer.Application.Services;

namespace Organizer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ListaController : ControllerBase
{
    private readonly IListaService _service;

    public ListaController(IListaService service)
    {
        _service = service;
    }

    [HttpGet("{listaId:int}")]
    public async Task<ActionResult<ListaDTO>> GetListaById(int listaId)
    {
        var listaExistente = await _service.PesquisarPorId(listaId);
        if (listaExistente == null) return NotFound();
        return Ok(listaExistente);
    }


    [HttpPost]
    public async Task<ActionResult<ListaDTO>> PostLista([FromBody] ListaDTO lista)
    {
        var listaCriada = await _service.Adicionar(lista);
        return CreatedAtAction(nameof(GetListaById), new { listaId = listaCriada.Id }, listaCriada);
    }
}