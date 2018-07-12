using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoSaudeVacina.Domain.Entities;
using ProjetoSaudeVacina.Domain.Interfaces.Repositories;

namespace ProjetoSaudeVacina.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PostoSaude")]
    public class PostoSaudeController : ControllerBase
    {
        private readonly IPostoSaudeRepository _postoSaudeRepository;

        public PostoSaudeController(IPostoSaudeRepository postoSaudeRepository)
        {
            _postoSaudeRepository = postoSaudeRepository;

            // Trecho de código para teste..
            // Remover quando em produção..
            if (_postoSaudeRepository.GetAll().Count() == 0)
            {
                _postoSaudeRepository.Add(
                    new PostoSaude
                    {
                        Nome = "Posto de Prazeres",
                        Latitude = -8,
                        Longitude = -31
                    }
                );
            }
        }

        // GET api/PostoSaude
        [HttpGet]
        public ActionResult<List<PostoSaude>> Get()
        {
            return _postoSaudeRepository.GetAll();
        }

        // GET api/PostoSaude/5
        [HttpGet("{id}")]
        public ActionResult<PostoSaude> Get(long id)
        {
            var item = _postoSaudeRepository.GetById(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // POST api/PostoSaude
        [HttpPost]
        public void Post([FromBody]PostoSaude item)
        {
        }

        // PUT api/PostoSaude/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]PostoSaude item)
        {
        }

        // DELETE api/PostoSaude/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}