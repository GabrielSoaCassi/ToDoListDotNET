using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Context;

public interface IOrganizerContext
{
    public DbSet<Lista> Listas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}