using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.API.Models.Cidadao.In;
using ProjetoSaudeVacina.API.Models.Cidadao.Out;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cidadao")]
    public class CidadaoController : ControllerBase
    {
        // Services..
        private readonly ICidadaoService _cidadaoService;

        public CidadaoController(ICidadaoService cidadaoService)
        {
            // Services..
            _cidadaoService = cidadaoService;
        }

        // GET api/Cidadao
        [HttpGet]
        public async Task<ActionResult<List<CidadaoGetOutViewModel>>> Get()
        {
            var item = await _cidadaoService.GetAllAsync();
            if (item == null)
                return NotFound();

            var result = Mapper.Map<List<CidadaoGetOutViewModel>>(item);

            return result;
        }

        // GET api/Cidadao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CidadaoGetOutViewModel>> Get(long id)
        {
            var item = await _cidadaoService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            var result = Mapper.Map<CidadaoGetOutViewModel>(item);

            return result;
        }

        // POST api/Cidadao
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CidadaoPostInViewModel item)
        {
            var entity = Mapper.Map<Cidadao>(item);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _cidadaoService.AddAsync(entity);
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

        // PUT api/Cidadao/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody]CidadaoPutInViewModel item)
        {
            var entity = await _cidadaoService.GetByIdAsync(id);
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
                await _cidadaoService.UpdateAsync(entity);
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

        // PUT api/Cidadao/5/Inativar
        [HttpPut("{id}/Inativar")]
        public async Task<ActionResult> Disable(long id)
        {
            var entity = await _cidadaoService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _cidadaoService.DisableAsync(entity);
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

        // POST api/Cidadao/Login
        [HttpPost("Login")]
        public async Task<ActionResult<CidadaoGetOutViewModel>> Login([FromBody]CidadaoLoginInViewModel item)
        {
            var model = await _cidadaoService.LoginAsync(item.Email, item.Senha);
            if (model == null)
                return NotFound();

            var result = Mapper.Map<CidadaoGetOutViewModel>(model);

            return result;
        }
    }
}