using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProConsulta.Models;

namespace ProConsulta.Data.Configurations;

public class AgendamentoConfiguration: IEntityTypeConfiguration<Agendamento>
{
    public void Configure(EntityTypeBuilder<Agendamento> builder)
    {
        builder.ToTable("Agendamentos");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Observacao)
            .IsRequired()
            .HasColumnType("VARCHAR(250)");

        builder.Property(a => a.PacienteId)
            .IsRequired();

        builder.Property(a => a.MedicoId)
            .IsRequired();

    }
}
