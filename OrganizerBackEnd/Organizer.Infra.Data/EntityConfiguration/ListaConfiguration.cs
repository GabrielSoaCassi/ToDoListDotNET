using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Organizer.Domain.Models;

namespace Organizer.Infra.Data.EntityConfiguration;

public class ListaConfiguration : IEntityTypeConfiguration<Lista>
{
    public void Configure(EntityTypeBuilder<Lista> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Nome)
            .HasMaxLength(200)
            .IsRequired();
    }
}