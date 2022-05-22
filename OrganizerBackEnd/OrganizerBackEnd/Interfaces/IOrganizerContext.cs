using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Interfaces
{
    public interface IOrganizerContext
  {
    int SaveChanges();
    public DbSet<Lista> Listas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
  }
}
