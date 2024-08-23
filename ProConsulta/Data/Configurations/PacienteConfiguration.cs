using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class PacienteConfiguration: IEntityTypeConfiguration<Paciente>
{
    public void Configure(EntityTypeBuilder<Paciente> builder)
    {
        builder.ToTable("Pacientes");
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Documento).IsUnique();

        builder.Property(p => p.Nome).IsRequired().HasColumnType("VARCHAR(50)");
        builder.Property(p => p.Documento).IsRequired().HasColumnType("NVARCHAR(11)");
        builder.Property(p => p.Email).IsRequired().HasColumnType("VARCHAR(50)");
        builder.Property(p => p.Celular).IsRequired().HasColumnType("NVARCHAR(11)");

        builder.HasMany(a => a.Agendamentos)
            .WithOne(p => p.Paciente)
            .HasForeignKey(a => a.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
