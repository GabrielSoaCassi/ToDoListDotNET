using AutoMapper;
using Organizer.Application.DTOs;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;

namespace Organizer.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly IMapper _mapper;
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }

    public async Task<TarefaDTO> Adicionar(TarefaDTO dto)
    {
        var tarefa = _mapper.Map<Tarefa>(dto);
        var tarefaCriada = await _repository.Adicionar(tarefa);
        return _mapper.Map<TarefaDTO>(tarefaCriada);
    }

    public async Task<TarefaDTO> Atualizar(TarefaDTO novaTarefa)
    {
        var tarefaExistente = await _repository.PesquisarPorId(novaTarefa.Id.Value);
        tarefaExistente.Update(novaTarefa.Nome, novaTarefa.ListaId);
        var tarefaAtualizada = await _repository.Atualizar(tarefaExistente);
        return _mapper.Map<TarefaDTO>(tarefaAtualizada);
    }

    public async Task<IEnumerable<TarefaDTO>> PesquisarPaginados(int listaId, int skip, int take)
    {
        var resultados = await _repository.PesquisarPaginados(listaId, skip, take);
        return _mapper.Map<IEnumerable<TarefaDTO>>(resultados);
    }

    public async Task<TarefaDTO> PesquisarPorId(int id)
    {
        var tarefa = await _repository.PesquisarPorId(id);
        return _mapper.Map<TarefaDTO>(tarefa);
    }

    public async Task Remover(int id)
    {
        await _repository.Remover(id);
    }
}