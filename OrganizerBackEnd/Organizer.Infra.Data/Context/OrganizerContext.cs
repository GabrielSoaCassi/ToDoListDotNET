using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organizer.Domain.Models;
using Organizer.Infra.Data.Identity;

namespace Organizer.Infra.Data.Context;

public class OrganizerContext : IdentityDbContext<ApplicationUser>
{
    public OrganizerContext(DbContextOptions<OrganizerContext> options) : base(options)
    {
    }

    public DbSet<Lista> Listas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrganizerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}