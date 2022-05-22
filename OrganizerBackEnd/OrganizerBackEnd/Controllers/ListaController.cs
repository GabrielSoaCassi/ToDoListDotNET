using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using System;
using System.Collections.Generic;

namespace OrganizerBackEnd.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ListaController : ControllerBase
    {
        private readonly IServices<Lista> _listaService;
        private readonly IMapper _mapper;

        public ListaController(IServices<Lista> service, IMapper mapper)
        {
            _listaService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarLista([FromBody] CreateListaDto listaDto)
        {
            var lista = _mapper.Map<Lista>(listaDto);
            try
            {
                 _listaService.Adicionar(lista);
                return Ok(lista);
            }
            catch (ArgumentException e)
            {
                return  Ok(e.Message);
            } 
        }

        [HttpGet]
        public List<Lista> ProcurarLista() =>
                _listaService.Pesquisar();

        [HttpGet("{id}")]
        public IActionResult PesquisarListaPorId(int id)
        {
            try
            {
                return Ok(_listaService.PesquisarPorId(id));
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarLista(int id, [FromBody] Lista listaAtualizada)
        {
            try
            {
                _listaService.Atualizar(id, listaAtualizada);
                return Ok(listaAtualizada);
            }
            catch(ArgumentException e)
            {
               return  Ok(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverLista(int id)
        {
            _listaService.Remover(id);
            return Ok(ProcurarLista());
        }
    }
}

