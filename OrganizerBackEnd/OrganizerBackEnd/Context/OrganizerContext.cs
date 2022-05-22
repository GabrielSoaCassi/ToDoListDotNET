using Microsoft.EntityFrameworkCore;
using OrganizerBackEnd.Interfaces;
using OrganizerBackEnd.Models;

namespace OrganizerBackEnd.Context
{
    public class OrganizerContext : DbContext, IOrganizerContext
    {
        public DbSet<Lista> Listas { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
        }
    }
}
