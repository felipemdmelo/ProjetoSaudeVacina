using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.TecnicoEnfermagem.In;
using ProjetoSaudeVacina.API.Models.TecnicoEnfermagem.Out;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/TecnicoEnfermagem")]
    public class TecnicoEnfermagemController : ControllerBase
    {
        // Services..
        private readonly ITecnicoEnfermagemService _tecnicoEnfermagemService;

        public TecnicoEnfermagemController(ITecnicoEnfermagemService tecnicoEnfermagemService)
        {
            // Services..
            _tecnicoEnfermagemService = tecnicoEnfermagemService;
        }

        // GET api/TecnicoEnfermagem
        [HttpGet]
        public async Task<ActionResult<List<TecnicoEnfermagemGetOutViewModel>>> Get()
        {
            var item = await _tecnicoEnfermagemService.GetAllAsync();
            if (item == null)
                return NotFound();

            var result = Mapper.Map<List<TecnicoEnfermagemGetOutViewModel>>(item);

            return result;
        }

        // GET api/TecnicoEnfermagem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TecnicoEnfermagemGetOutViewModel>> Get(long id)
        {
            var item = await _tecnicoEnfermagemService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var result = Mapper.Map<TecnicoEnfermagemGetOutViewModel>(item);

            return result;
        }

        // POST api/TecnicoEnfermagem
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]TecnicoEnfermagemPostInViewModel item)
        {
            var entity = Mapper.Map<TecnicoEnfermagem>(item);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _tecnicoEnfermagemService.AddAsync(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        Error = "Ocorreu um erro para salvar os dados. Tente novamente mais tarde! Se o problema persistir entre em contato com o suporte técnico.",
                        ex.Message,
                        ex.InnerException
                    }
                );
            }

            return Ok();
        }

        // PUT api/TecnicoEnfermagem/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]TecnicoEnfermagemPutInViewModel item)
        {
            var entity = await _tecnicoEnfermagemService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            entity = Mapper.Map(item, entity);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _tecnicoEnfermagemService.UpdateAsync(entity);
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

        // PUT api/TecnicoEnfermagem/5/Inativar
        [HttpPut("{id}/Inativar")]
        public async Task<ActionResult> Disable(long id)
        {
            var entity = await _tecnicoEnfermagemService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _tecnicoEnfermagemService.DisableAsync(entity);
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