using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.In;
using ProjetoSaudeVacina.API.Models.VacinaEstoqueLancamento.Out;
using ProjetoSaudeVacina.Domain.Entities;
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
            var posto = item[0].PostoSaude;
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

        // POST api/Lancamento
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]VacinaEstoqueLancamentoPostInViewModel item)
        {
            var entity = Mapper.Map<VacinaEstoqueLancamento>(item);

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

        // PUT api/Lancamento/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]VacinaEstoqueLancamentoPutInViewModel item)
        {
            var entity = await _vacinaEstoqueLancamentoService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // entity = Mapper.Map<Vacina>(item); Analisar o mapper, para que faça uma mesclagem entre entity e item..
            //entity.Nome = item.Nome;

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacinaEstoqueLancamentoService.UpdateAsync(entity);
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

        // DELETE api/Lancamento/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _vacinaEstoqueLancamentoService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _vacinaEstoqueLancamentoService.RemoveAsync(entity);
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
    }
}