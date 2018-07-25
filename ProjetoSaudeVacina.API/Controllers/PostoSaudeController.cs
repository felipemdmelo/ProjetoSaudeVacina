using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.PostoSaude.In;
using ProjetoSaudeVacina.API.Models.PostoSaude.Out;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PostoSaude")]
    public class PostoSaudeController : ControllerBase
    {
        // Services..
        private readonly IPostoSaudeService _postoSaudeService;

        public PostoSaudeController(IPostoSaudeService postoSaudeService)
        {
            // Services..
            _postoSaudeService = postoSaudeService;
        }

        // GET api/PostoSaude
        [HttpGet]
        public async Task<ActionResult<List<PostoSaudeGetOutViewModel>>> Get()
        {
            var item = await _postoSaudeService.GetAllAsync();
            if (item == null)
                return NotFound();

            var result = Mapper.Map<List<PostoSaudeGetOutViewModel>>(item);

            return result;
        }

        // GET api/PostoSaude/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostoSaudeGetOutViewModel>> Get(long id)
        {
            var item = await _postoSaudeService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var result = Mapper.Map<PostoSaudeGetOutViewModel>(item);

            return result;
        }

        // POST api/PostoSaude
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]PostoSaudePostInViewModel item)
        {
            var entity = Mapper.Map<PostoSaude>(item);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _postoSaudeService.AddAsync(entity);
            }
            catch(Exception ex)
            {
                return BadRequest(
                    new {
                        Error = "Ocorreu um erro para salvar os dados. Tente novamente mais tarde! Se o problema persistir entre em contato com o suporte técnico.",
                        ex.Message,
                        ex.InnerException
                    }
                );
            }

            return Ok();
        }

        // PUT api/PostoSaude/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]PostoSaudePutInViewModel item)
        {
            var entity = await _postoSaudeService.GetByIdAsync(id);
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
                await _postoSaudeService.UpdateAsync(entity);
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

        // PUT api/PostoSaude/5/Inativar
        [HttpPut("{id}/Inativar")]
        public async Task<ActionResult> Disable(long id)
        {
            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _postoSaudeService.DisableAsync(entity);
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