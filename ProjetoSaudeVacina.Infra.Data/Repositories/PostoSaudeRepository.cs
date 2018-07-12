﻿using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoSaudeVacina.Infra.Data.Repositories
{
    public class PostoSaudeRepository : GenericRepository<PostoSaude>, IPostoSaudeRepository
    {
        public PostoSaudeRepository(ProjetoSaudeVacinaContext db) : base(db)
        {
        }
    }
}
