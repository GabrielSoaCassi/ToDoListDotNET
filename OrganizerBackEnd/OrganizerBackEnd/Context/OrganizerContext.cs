using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Context;

public class OrganizerContext : DbContext, IOrganizerContext
{
    public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
    {
    }

    public DbSet<Lista> Listas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
    }
}