using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.Vacina.In;
using ProjetoSaudeVacina.API.Models.Vacina.Out;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacina")]
    public class VacinaController : ControllerBase
    {
        // Services..
        private readonly IVacinaService _vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            // Services..
            _vacinaService = vacinaService;
        }

        // GET api/Vacina
        [HttpGet]
        public async Task<ActionResult<List<VacinaGetOutViewModel>>> Get()
        {
            var item = await _vacinaService.GetAllAsync();
            if (item == null)
                return NotFound();

            var result = Mapper.Map<List<VacinaGetOutViewModel>>(item);

            return result;
        }

        // GET api/Vacina/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VacinaGetOutViewModel>> Get(long id)
        {
            var item = await _vacinaService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var result = Mapper.Map<VacinaGetOutViewModel>(item);

            return result;
        }

        // POST api/Vacina
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]VacinaPostInViewModel item)
        {
            var entity = Mapper.Map<Vacina>(item);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacinaService.AddAsync(entity);
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

        // PUT api/Vacina/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]VacinaPutInViewModel item)
        {
            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // entity = Mapper.Map<Vacina>(item); Analisar o mapper, para que faça uma mesclagem entre entity e item..
            entity.Nome = item.Nome;

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacinaService.UpdateAsync(entity);
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

        // DELETE api/Vacina/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _vacinaService.RemoveAsync(entity);
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