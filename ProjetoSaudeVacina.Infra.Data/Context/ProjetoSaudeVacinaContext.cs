using Microsoft.EntityFrameworkCore;
using ProjetoSaudeVacina.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoSaudeVacina.Infra.Data.Context
{
    public class ProjetoSaudeVacinaContext : DbContext
    {
        public DbSet<Cidadao> Cidadao { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<PostoSaude> PostoSaude { get; set; }
        public DbSet<TecnicoEnfermagem> TecnicoEnfermagem { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<VacinaEstoqueLancamento> VacinaEstoqueLancamento { get; set; }

        public ProjetoSaudeVacinaContext(DbContextOptions<ProjetoSaudeVacinaContext> options) : base(options)
        {
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Este código remove o comportamento Cascade do On Delete de todas
             * as Entidades do Model
             */
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            // Configurações de Pessoa..
            modelBuilder.Entity<Pessoa>()
                .HasIndex(u => u.CPF)
                .IsUnique();
            modelBuilder.Entity<Pessoa>()
                .HasIndex(u => u.Email)
                .IsUnique();

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
