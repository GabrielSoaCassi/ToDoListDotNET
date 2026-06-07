using AutoMapper;
using Organizer.Application.DTOs;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;

namespace Organizer.Application.Services;

public class TarefaService : IService<TarefaDTO>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Tarefa> _repository;

    public TarefaService(IRepository<Tarefa> repository, IMapper mapper)
    {
        _repository = _repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }

    public async Task<TarefaDTO> Adicionar(TarefaDTO dto)
    {
        var tarefa = _mapper.Map<Tarefa>(dto);
        var tarefaCriada = await _repository.Adicionar(tarefa);
        return _mapper.Map<TarefaDTO>(tarefaCriada);
    }

    public async Task<TarefaDTO> Atualizar(int id, TarefaDTO novaTarefa)
    {
        var tarefa = _mapper.Map<Tarefa>(novaTarefa);
        var tarefaAtualizada = await _repository.Adicionar(tarefa);
        return _mapper.Map<TarefaDTO>(tarefaAtualizada);
    }

    public async Task<IEnumerable<TarefaDTO>> PesquisarPaginados(int skip, int take)
    {
        var resultados = await _repository.PesquisarPaginados(skip, take);
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

    public async Task<IEnumerable<TarefaDTO>> Pesquisar()
    {
        throw new NotImplementedException("This method is not implemented");
    }
}