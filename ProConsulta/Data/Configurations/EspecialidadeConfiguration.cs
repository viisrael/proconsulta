using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class EspecialidadeConfiguration: IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.ToTable("Especialidades");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(60)");

        builder.Property(e => e.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.HasMany(m => m.Medicos)
            .WithOne(e => e.Especialidade)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
