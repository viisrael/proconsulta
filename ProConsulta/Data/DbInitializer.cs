using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProConsulta.Models;

namespace ProConsulta.Data;

public class DbInitializer
{
    private readonly ModelBuilder _modelBuilder;


    public DbInitializer(ModelBuilder modelBuilder)
    {
        _modelBuilder = modelBuilder;
    }

    internal void seed()
    {
        _modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "06092c81-bba0-4236-9e6b-4a4b18257a1f",
                Name = "Atendente",
                NormalizedName = "ATENDENTE"
            },
            new IdentityRole
            {
                Id = "72b18e1e-6965-4d97-9fa2-19090afeb3fe",
                Name = "Médico",
                NormalizedName = "MÉDICO"
            }
        );

        var hasher = new PasswordHasher<IdentityUser>();

        _modelBuilder.Entity<Atendente>().HasData(
            new Atendente
            {
                Id = "0d2d69a2-577a-401a-b65a-3ff2e3039b09",
                Nome = "Atendente I",
                Email = "atendente@email.com",
                EmailConfirmed = true,
                UserName = "atendente",
                NormalizedEmail = "ATENDENTE@EMAIL.COM",
                NormalizedUserName = "ATENDENTE@EMAIL.COM",
                PasswordHash = hasher.HashPassword(null, "s3nh4")
            }
        
            
        );

        _modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "06092c81-bba0-4236-9e6b-4a4b18257a1f",
                   UserId = "0d2d69a2-577a-401a-b65a-3ff2e3039b09"
               }
        );

        _modelBuilder.Entity<Especialidade>().HasData(
            new Especialidade { Id = 1, Nome = "Cardiologia", Descricao = "Descrição do cardiologista" },    
            new Especialidade { Id = 2, Nome = "Dermatologia", Descricao = "Descrição do dermatologista" },    
            new Especialidade { Id = 3, Nome = "Gastroenterologia", Descricao = "Descrição do gastroenterologia" },    
            new Especialidade { Id = 4, Nome = "Neurologia", Descricao = "Descrição do neurologia" },    
            new Especialidade { Id = 5, Nome = "Ortopedia", Descricao = "Descrição do ortopedia" },    
            new Especialidade { Id = 6, Nome = "Pediatria", Descricao = "Descrição do pediatria" }   
        );
    }
}
