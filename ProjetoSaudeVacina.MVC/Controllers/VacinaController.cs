using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Services;
using ProjetoSaudeVacina.MVC.Models.Vacina.In;
using ProjetoSaudeVacina.MVC.Models.Vacina.Out;

namespace ProjetoSaudeVacina.MVC.Controllers
{
    public class VacinaController : Controller
    {
        // Services..
        private readonly IVacinaService _vacinaService;

        public VacinaController(IVacinaService vacinaService)
        {
            // Services..
            _vacinaService = vacinaService;
        }

        // GET: Vacina
        public async Task<ActionResult> Index()
        {
            var entity = await _vacinaService.GetAllAsync();
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<List<VacinaGetOutViewModel>>(entity);

            return View(model);
        }

        // GET: Vacina/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if(id == 0)
                return NotFound();

            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<VacinaGetOutViewModel>(entity);

            return View(model);
        }

        // GET: Vacina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vacina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VacinaPostInViewModel model)
        {
            var entity = Mapper.Map<Vacina>(model);

            // Verifica se a o model está preenchido corretamente..
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _vacinaService.AddAsync(entity);
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

        // GET: Vacina/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<VacinaPutInViewModel>(entity);

            return View(model);
        }

        // POST: Vacina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, VacinaPutInViewModel model)
        {
            if (id == 0)
                return NotFound();

            var entity = await _vacinaService.GetByIdAsync(id);
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
                await _vacinaService.UpdateAsync(entity);
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

        // GET: Vacina/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            var model = Mapper.Map<VacinaGetOutViewModel>(entity);

            return View(model);
        }

        // POST: Vacina/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            if (id == 0)
                return NotFound();

            var entity = await _vacinaService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            try
            {
                await _vacinaService.DisableAsync(entity);
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