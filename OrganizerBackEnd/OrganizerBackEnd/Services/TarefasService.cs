using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Services;

public class TarefasService : IService<Tarefa>
{
    private readonly IOrganizerContext _context;

    public TarefasService(IOrganizerContext context)
    {
        _context = context;
    }

    public async Task<Tarefa> Adicionar(Tarefa tarefa)
    {
        if (!string.IsNullOrEmpty(tarefa.Nome) && tarefa.ListaId != 0)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        throw new ArgumentException("Tarefa sem nome ou sem referência a lista, dado não inserido no banco");
    }

    public async Task<Tarefa> Atualizar(int id, Tarefa novaTarefa)
    {
        if (id != 0 && !string.IsNullOrEmpty(novaTarefa.Nome) && !string.IsNullOrWhiteSpace(novaTarefa.Nome))
        {
            novaTarefa.Id = id;
            _context.Tarefas.Update(novaTarefa);
            await _context.SaveChangesAsync();
            return novaTarefa;
        }

        throw new ArgumentException("Parâmetro de ID ou tarefa invalida. Verifque e tente novamente");
    }

    public async Task<IEnumerable<Tarefa>> PesquisarPaginados(int skip, int take)
    {
        var resultado = _context.Tarefas.AsNoTracking().Skip((skip - 1) * take).Take(take).ToListAsync();
        return resultado.Result;
    }

    public async Task<Tarefa> PesquisarPorId(int id)
    {
        var tarefa = await _context.Tarefas.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        if (tarefa != null)
            return tarefa;
        throw new ArgumentException("Tarefa não encontrada");
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