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
    public class EnderecosController : ControllerBase
    {
        private ApplicationDbContext _context;

        public EnderecosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<Enderecos> Get()
        {
            return _context.Enderecos;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Post(Enderecos endereco)
        {
            if (endereco != null)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();

                return Ok("Endereço cadastrado com sucesso !");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Route("")]
        public IActionResult Remove(Guid Id)
        {
            var endereco = _context.Enderecos.First(X => X.Id == Id);

            if (endereco != null)
            {
                _context.Enderecos.Remove(endereco);
                _context.SaveChanges();

                return Ok("Endereço removido com sucesso !");
            }

            return BadRequest("Endereço não localizado !");
        }


        [HttpPut("{Id}")]
        [Route("")]
        public IActionResult Put(Guid Id, Enderecos dados)
        {
            var endereco = _context.Enderecos.First(Y => Y.Id == Id);

            if (endereco != null)
            {
                endereco.Rua = string.IsNullOrEmpty(dados.Rua) ? endereco.Rua : dados.Rua;
                endereco.Numero = (dados.Numero < 0) ? endereco.Numero : dados.Numero;
                endereco.Cidade = string.IsNullOrEmpty(dados.Cidade) ? endereco.Cidade : dados.Cidade;
                endereco.CEP = string.IsNullOrEmpty(dados.CEP) ? endereco.CEP : dados.CEP;
                _context.Enderecos.Update(endereco);
                _context.SaveChanges();


                return Ok(endereco);

            }

            return BadRequest("Não foi possivel atualizar as informações! ");
        }
    }
}

