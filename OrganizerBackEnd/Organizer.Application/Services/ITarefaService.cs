using Organizer.Application.DTOs;

namespace Organizer.Application.Services;

public interface ITarefaService
{
    Task<TarefaDTO> Adicionar(TarefaDTO opt);
    Task Remover(int id);
    Task<TarefaDTO> Atualizar(TarefaDTO opt);
    Task<TarefaDTO> PesquisarPorId(int id);
    Task<IEnumerable<TarefaDTO>> PesquisarPaginados(int listaId, int skip, int take);
}