using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;
using Organizer.Infra.Data.Context;

namespace Organizer.Infra.Data.Repository;

public class TarefasRepository : IRepository<Tarefa>
{
    private readonly OrganizerContext _context;

    public TarefasRepository(OrganizerContext context)
    {
        _context = context;
    }

    public async Task<Tarefa> Adicionar(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task<Tarefa> Atualizar(int id, Tarefa novaTarefa)
    {
        _context.Tarefas.Update(novaTarefa);
        await _context.SaveChangesAsync();
        return novaTarefa;
    }

    public async Task<IEnumerable<Tarefa>> PesquisarPaginados(int skip, int take)
    {
        var resultado = _context.Tarefas.AsNoTracking().Skip((skip - 1) * take).Take(take).ToListAsync();
        return resultado.Result;
    }

    public async Task<Tarefa> PesquisarPorId(int id)
    {
        var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        return tarefa;
    }

    public async Task Remover(int id)
    {
        await _context.Tarefas.Where(t => t.Id.Equals(id)).ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Tarefa>> Pesquisar()
    {
        throw new NotImplementedException("This method is not implemented");
    }
}