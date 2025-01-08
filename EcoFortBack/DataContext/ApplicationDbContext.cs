using CRM.Models;
using Microsoft.EntityFrameworkCore;
using CRM.Enums;

namespace CRM.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ContasModel> Contas { get; set; }
        public DbSet<ContatosModel> Contatos { get; set; }
        public DbSet<ReportsModel> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeando o enum Cargo como string no banco de dados
            modelBuilder.Entity<ContatosModel>()
                .Property(c => c.Cargo)
                .HasConversion(
                    v => v.ToString(), // Salva como string no banco
                    v => (Cargo)Enum.Parse(typeof(Cargo), v) // Converte de volta para enum ao carregar
                );

            // Mapeando o enum Sexo como string no banco de dados
            modelBuilder.Entity<ContatosModel>()
                .Property(c => c.Sexo)
                .HasConversion(
                    v => v.ToString(), // Salva como string no banco
                    v => (Sexo)Enum.Parse(typeof(Sexo), v) // Converte de volta para enum ao carregar
                );
        }
    }
}
