using AutoMapper;
using Organizer.Application.DTOs;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;

namespace Organizer.Application.Services;

public class ListaService : IListaService
{
    private readonly IMapper _mapper;
    private readonly IListaRepository _repository;

    public ListaService(IListaRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper;
    }

    public async Task<ListaDTO> Adicionar(ListaDTO dto)
    {
        var lista = _mapper.Map<Lista>(dto);
        var listaCriada = await _repository.Adicionar(lista);
        return _mapper.Map<ListaDTO>(listaCriada);
    }

    public async Task<ListaDTO> Atualizar(int id, ListaDTO novalista)
    {
        var lista = _mapper.Map<Lista>(novalista);
        var listaAtualizada = await _repository.Adicionar(lista);
        return _mapper.Map<ListaDTO>(listaAtualizada);
    }

    public async Task<IEnumerable<ListaDTO>> PesquisarPaginados(int skip, int take)
    {
        var resultados = await _repository.PesquisarPaginados(skip, take);
        return _mapper.Map<IEnumerable<ListaDTO>>(resultados);
    }

    public async Task<ListaDTO> PesquisarPorId(int id)
    {
        var lista = await _repository.PesquisarPorId(id);
        return _mapper.Map<ListaDTO>(lista);
    }

    public async Task Remover(int id)
    {
        await _repository.Remover(id);
    }

    public async Task<IEnumerable<ListaDTO>> Pesquisar()
    {
        throw new NotImplementedException("This method is not implemented");
    }
}