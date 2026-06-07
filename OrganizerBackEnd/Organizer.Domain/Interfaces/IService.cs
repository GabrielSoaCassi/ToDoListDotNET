namespace Organizer.Domain.Interfaces;

public interface IService<T>
{
    Task<T> Adicionar(T opt);
    Task Remover(int id);
    Task<T> Atualizar(int id, T opt);
    Task<T> PesquisarPorId(int id);
    Task<IEnumerable<T>> PesquisarPaginados(int skip, int take);
}