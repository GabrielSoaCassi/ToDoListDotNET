using Organizer.Domain.Models;

namespace Organizer.Domain.Interfaces;

public interface ITarefaRepository
{
    Task<Tarefa> Adicionar(Tarefa opt);
    Task Remover(int id);
    Task<Tarefa> Atualizar(Tarefa opt);
    Task<Tarefa> PesquisarPorId(int id);
    Task<IEnumerable<Tarefa>> PesquisarPaginados(int listaId, int skip, int take);
}