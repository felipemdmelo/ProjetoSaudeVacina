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
        public DbSet<VacinaEstoque> VacinaEstoque { get; set; }
        public DbSet<VacinaEstoqueItem> VacinaEstoqueItem { get; set; }

        public ProjetoSaudeVacinaContext(DbContextOptions<ProjetoSaudeVacinaContext> options) : base(options)
        {
            //Database.Migrate();
        }
    }
}
