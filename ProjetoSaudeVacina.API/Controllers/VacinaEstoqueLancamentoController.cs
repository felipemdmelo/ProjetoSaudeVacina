using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.Out;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Entities.Enums;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Lancamento")]
    public class VacinaEstoqueLancamentoController : ControllerBase
    {
        // Services..
        private readonly IVacinaEstoqueLancamentoService _vacinaEstoqueLancamentoService;

        public VacinaEstoqueLancamentoController(IVacinaEstoqueLancamentoService vacinaEstoqueLancamentoService)
        {
            // Services..
            _vacinaEstoqueLancamentoService = vacinaEstoqueLancamentoService;
        }

        // GET api/Lancamento
        [HttpGet]
        public async Task<ActionResult<List<VacinaEstoqueLancamentoGetOutViewModel>>> Get()
        {
            var item = await _vacinaEstoqueLancamentoService.GetAllAsync();
            if (item == null)
                return NotFound();

            var result = Mapper.Map<List<VacinaEstoqueLancamentoGetOutViewModel>>(item);

            return result;
        }

        // GET api/Lancamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacinaEstoqueLancamentoGetOutViewModel>> Get(long id)
        {
            var item = await _vacinaEstoqueLancamentoService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var result = Mapper.Map<VacinaEstoqueLancamentoGetOutViewModel>(item);

            return result;
        }

        // POST api/Lancamento/Abastecimento
        [HttpPost("Abastecimento")]
        public async Task<ActionResult> PostAbastecimento([FromBody]VacinaEstoqueLancamentoAbastecimentoPostInViewModel item)
        {
            return await Post(item, LancamentoEnum.Abastecimento);
        }

        // POST api/Lancamento/Aplicacao
        [HttpPost("Aplicacao")]
        public async Task<ActionResult> PostAplicacao([FromBody]VacinaEstoqueLancamentoAplicacaoPostInViewModel item)
        {
            return await Post(item, LancamentoEnum.Aplicacao);
        }

        // PUT api/Lancamento/5/Inativar
        [HttpPut("{id}/Inativar")]
        public async Task<ActionResult> Disable(long id)
        {
            var entity = await _vacinaEstoqueLancamentoService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _vacinaEstoqueLancamentoService.DisableAsync(entity);
            }
            catch (Exception)
            {
                return BadRequest(
                    new
                    {
                        Error = "Ocorreu um erro para salvar os dados. Tente novamente mais tarde! Se o problema persistir entre em contato com o suporte técnico."
                    }
                );
            }

            return Ok();
        }

        #region PRIVATE METHODS
        private async Task<ActionResult> Post(VacinaEstoqueLancamentoPostInViewModel item, LancamentoEnum tipo)
        {
            var entity = Mapper.Map<VacinaEstoqueLancamento>(item);
            entity.Tipo = tipo;

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacinaEstoqueLancamentoService.AddAsync(entity);
            }
            catch (Exception)
            {
                return BadRequest(
                    new
                    {
                        Error = "Ocorreu um erro para salvar os dados. Tente novamente mais tarde! Se o problema persistir entre em contato com o suporte técnico."
                    }
                );
            }

            return Ok();
        }
        #endregion
    }
}