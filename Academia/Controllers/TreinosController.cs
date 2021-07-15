using Academia.Data;
using Academia.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TreinosController : ControllerBase
    {

        private ApplicationDbContext _context;


        public TreinosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<Treinos> Get()
        {
            return _context.Treinos;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post(Treinos treino)
        {
            if (treino != null)
            {
                _context.Treinos.Add(treino);
                _context.SaveChanges();

                return Ok ("Treino cadastrado com sucesso !");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Route("")]
        public IActionResult Remove(Guid Id)
        {
            var treino = _context.Treinos.First(X => X.Id == Id);

            if (treino != null)
            {
                _context.Treinos.Remove(treino);
                _context.SaveChanges();

                return Ok("Treino removido com sucesso !");
            }

            return BadRequest("Treino não localizado !");
        }

        [HttpPut("{Id}")]
        [Route("")]
        public IActionResult Put(Guid Id, Treinos dados)
        {
            var treino = _context.Treinos.First(Y => Y.Id == Id);

            if (treino != null)
            {
                treino.NomeSerie = string.IsNullOrEmpty(dados.NomeSerie) ? treino.NomeSerie : dados.NomeSerie;
                treino.ParteCorpo = string.IsNullOrEmpty(dados.ParteCorpo) ? treino.ParteCorpo : dados.ParteCorpo;
                treino.QuantidadeSerie = (dados.QuantidadeSerie <= 0) ? treino.QuantidadeSerie : dados.QuantidadeSerie;
                treino.Repeticoes = (dados.Repeticoes <= 0) ? treino.Repeticoes : dados.Repeticoes;


                _context.Treinos.Update(treino);
                _context.SaveChanges();


                return Ok(treino);

            }

            return BadRequest("Não foi possivel atualizar as informações!");
        }
    }
}

