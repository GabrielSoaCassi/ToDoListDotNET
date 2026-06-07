using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizer.Domain.Models;

namespace Organizer.Infra.Data.EntityConfiguration;

public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
{
    public void Configure(EntityTypeBuilder<Tarefa> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.ListaId);
        builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
        builder.HasOne(e => e.Lista)
            .WithMany(e => e.Tarefas)
            .HasForeignKey(x => x.ListaId);
    }
}