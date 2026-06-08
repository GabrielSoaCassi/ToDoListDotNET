using Organizer.Domain.Models;

namespace Organizer.Domain.Interfaces;

public interface IListaRepository
{
    Task<Lista> Adicionar(Lista opt);
    Task Remover(int id);
    Task<Lista> Atualizar(int id, Lista opt);
    Task<Lista> PesquisarPorId(int id);
    Task<IEnumerable<Lista>> PesquisarPaginados(int skip, int take);
}