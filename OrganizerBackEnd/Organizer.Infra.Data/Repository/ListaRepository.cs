using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Interfaces;
using Organizer.Domain.Models;
using Organizer.Infra.Data.Context;

namespace Organizer.Infra.Data.Repository;

public class ListaRepository : IListaRepository
{
    private readonly OrganizerContext _context;

    public ListaRepository(OrganizerContext context)
    {
        _context = context;
    }

    public async Task<Lista> Adicionar(Lista lista)
    {
        _context.Listas.Add(lista);
        await _context.SaveChangesAsync();
        return lista;
    }

    public async Task<Lista> Atualizar(int id, Lista listaAtualizada)
    {
        _context.Listas.Update(listaAtualizada);
        await _context.SaveChangesAsync();
        return listaAtualizada;
    }

    public async Task<IEnumerable<Lista>> PesquisarPaginados(int skip = 1, int take = 5)
    {
        var resultado = _context.Listas.AsNoTracking().Skip((skip - 1) * take).Take(take).ToListAsync();
        return resultado.Result;
    }

    public async Task<Lista> PesquisarPorId(int id)
    {
        var resultado = await _context.Listas.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        return resultado;
    }

    public async Task Remover(int id)
    {
        await _context.Listas.Where(l => l.Id.Equals(id)).ExecuteDeleteAsync();
    }

    public Task<IEnumerable<Lista>> Pesquisar()
    {
        throw new NotImplementedException("This Method is not implemented");
    }
}