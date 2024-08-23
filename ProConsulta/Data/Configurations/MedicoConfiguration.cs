using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class MedicoConfiguration: IEntityTypeConfiguration<Medico>
{
    public void Configure(EntityTypeBuilder<Medico> builder)
    {
        builder.ToTable("Medicos");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder.Property(m => m.Documento)
            .IsRequired()
            .HasColumnType("NVARCHAR(11)");

        builder.Property(m => m.Crm)
            .IsRequired()
            .HasColumnType("NVARCHAR(8)");

        builder.Property(m => m.Celular)
            .IsRequired()
            .HasColumnType("NVARCHAR(11)");

        builder.Property(m => m.EspecialidadeId)
            .IsRequired();

        builder.HasIndex(m => m.Documento).IsUnique();

        builder.HasMany(a => a.Agendamentos)
            .WithOne(m => m.Medico)
            .HasForeignKey(a => a.MedicoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
