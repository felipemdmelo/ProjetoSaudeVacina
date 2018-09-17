using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using ProjetoSaudeVacina.MVC.Models.PostoSaude.In;
using ProjetoSaudeVacina.MVC.Models.PostoSaude.Out;

namespace ProjetoSaudeVacina.MVC.Controllers
{
    public class PostoSaudeController : Controller
    {
        // Services..
        private readonly IPostoSaudeService _postoSaudeService;

        public PostoSaudeController(IPostoSaudeService postoSaudeService)
        {
            // Services..
            _postoSaudeService = postoSaudeService;
        }

        // GET: PostoSaude
        public async Task<ActionResult> Index()
        {
            var entity = await _postoSaudeService.GetAllAsync();
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<List<PostoSaudeGetOutViewModel>>(entity);

            return View(model);
        }

        // GET: PostoSaude/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<PostoSaudeGetOutViewModel>(entity);

            return View(model);
        }

        // GET: PostoSaude/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostoSaude/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PostoSaudePostInViewModel model)
        {
            var entity = Mapper.Map<PostoSaude>(model);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _postoSaudeService.AddAsync(entity);
                return RedirectToAction(nameof(Index));
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
        }

        // GET: PostoSaude/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<PostoSaudePutInViewModel>(entity);

            return View(model);
        }

        // POST: PostoSaude/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, PostoSaudePutInViewModel model)
        {
            if (id == 0)
                return NotFound();

            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Mapper.Map(model, entity);

            try
            {
                await _postoSaudeService.UpdateAsync(entity);
                return RedirectToAction(nameof(Index));
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
        }

        // GET: PostoSaude/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<PostoSaudeGetOutViewModel>(entity);

            return View(model);
        }

        // POST: PostoSaude/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            if (id == 0)
                return NotFound();

            var entity = await _postoSaudeService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _postoSaudeService.DisableAsync(entity);
                return RedirectToAction(nameof(Index));
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
        }
    }
}