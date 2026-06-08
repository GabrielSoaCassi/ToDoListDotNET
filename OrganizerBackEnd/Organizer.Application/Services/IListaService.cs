using Organizer.Application.DTOs;

namespace Organizer.Application.Services;

public interface IListaService
{
    Task<ListaDTO> Adicionar(ListaDTO opt);
    Task Remover(int id);
    Task<ListaDTO> Atualizar(int id, ListaDTO opt);
    Task<ListaDTO> PesquisarPorId(int id);
    Task<IEnumerable<ListaDTO>> PesquisarPaginados(int skip, int take);
}