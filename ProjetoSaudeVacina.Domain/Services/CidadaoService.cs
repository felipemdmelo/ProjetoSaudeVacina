﻿using System;
using System.Threading.Tasks;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Exceptions;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.Domain.Services
{
    public class CidadaoService : GenericService<Cidadao>, ICidadaoService
    {
        private readonly ICidadaoRepository _repository;

        public CidadaoService(ICidadaoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Cidadao obj)
        {
            if (await ExistsByCPFOrEmail(obj.CPF, obj.Email))
                throw new DomainException("Já existe um cadastro com este CPF e/ou Email.");

            await _repository.AddAsync(obj);
        }

        private async Task<bool> ExistsByCPFOrEmail(string cpf, string email)
        {
            return await _repository.ExistsByCPFOrEmail(cpf, email);
        }

        public async Task<Cidadao> LoginAsync(string email, string senha)
        {
            return await _repository.LoginAsync(email, senha);
        }
    }
}
