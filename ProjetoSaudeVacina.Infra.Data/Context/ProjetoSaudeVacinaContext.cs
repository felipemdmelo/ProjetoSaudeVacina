using Microsoft.EntityFrameworkCore;
using ProjetoSaudeVacina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Infra.Data.Context
{
    public class ProjetoSaudeVacinaContext : DbContext
    {
        public DbSet<PostoSaude> PostoSaude { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<VacinaEstoqueLancamento> VacinaEstoqueLancamento { get; set; }

        public ProjetoSaudeVacinaContext(DbContextOptions<ProjetoSaudeVacinaContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de PostoSaude..
            modelBuilder.Entity<PostoSaude>()
                .HasIndex(u => u.Nome)
                .IsUnique();

            // Configurações de Vacina..
            modelBuilder.Entity<Vacina>()
                .HasIndex(u => u.Nome)
                .IsUnique();
        }
    }
}
