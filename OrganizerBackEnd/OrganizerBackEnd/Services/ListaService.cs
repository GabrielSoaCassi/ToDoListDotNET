using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Context;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Services;

public class ListaService : IService<Lista>
{
    private readonly IOrganizerContext _context;

    public ListaService(IOrganizerContext context)
    {
        _context = context;
    }

    public async Task<Lista> Adicionar(Lista lista)
    {
        if (!string.IsNullOrEmpty(lista.Nome))
        {
            _context.Listas.Add(lista);
            await _context.SaveChangesAsync();
            return lista;
        }

        throw new ArgumentException("Lista nula ou parâmetro inválido, dado não inserido no Banco.");
    }

    public async Task<Lista> Atualizar(int id, Lista listaAtualizada)
    {
        if (id != 0 && !string.IsNullOrEmpty(listaAtualizada.Nome) && !string.IsNullOrWhiteSpace(listaAtualizada.Nome))
        {
            listaAtualizada.Id = id;
            _context.Listas.Update(listaAtualizada);
            await _context.SaveChangesAsync();
            return listaAtualizada;
        }

        throw new ArgumentException("Parâmetro de ID ou lista invalida. Verifique e tente novamente");
    }

    public async Task<IEnumerable<Lista>> PesquisarPaginados(int skip = 1, int take = 5)
    {
        var resultado = _context.Listas.AsNoTracking().Skip((skip - 1) * take).Take(take).ToListAsync();
        return resultado.Result;
    }

    public async Task<Lista> PesquisarPorId(int id)
    {
        var resultado = await _context.Listas.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
        if (resultado != null)
            return resultado;

        throw new ArgumentException("Lista não encontrada");
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