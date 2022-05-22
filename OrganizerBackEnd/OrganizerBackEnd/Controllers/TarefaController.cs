using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizerBackEnd.Dto;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;
using System;
using System.Collections.Generic;

namespace OrganizerBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly IServices<Tarefa> _serviceTarefa;
        private readonly IMapper _mapper;

        public TarefaController(IServices<Tarefa> service,IMapper mapper)
        {
            _serviceTarefa = service;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarTarefa([FromBody] CreateTarefaDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            try
            {
                _serviceTarefa.Adicionar(tarefa);
                return Ok(tarefa);
            }
            catch (ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpGet]
        public List<Tarefa> ProcurarTarefa() =>
            _serviceTarefa.Pesquisar();

        [HttpGet("{id}")]
        public IActionResult PesquisarTarefaPorId(int id)
        {
            try
            {
                return Ok(_serviceTarefa.PesquisarPorId(id));
            }
            catch(ArgumentException e)
            {
                return Ok(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa(int id, [FromBody] Tarefa tarefaAtualizada)
        {
            _serviceTarefa.Atualizar(id, tarefaAtualizada);
            return Ok(tarefaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverTarefa(int id)
        {
            _serviceTarefa.Remover(id);
            return Ok(ProcurarTarefa());
        }
    }
}
