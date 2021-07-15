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
    public class ClientesController : ControllerBase
    {
        private ApplicationDbContext _context;
        

        public ClientesController (ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route ("")]
        public IEnumerable<Clientes> Get()
        {
            return _context.Clientes;
        }

        [HttpPost]
        [Route("")]

        public IActionResult Post (Clientes cliente)
        {
            if (cliente != null)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return Ok("Cliente cadastrado com sucesso !");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Route("")]
        public IActionResult Remove (Guid Id)
        {
            var cliente = _context.Clientes.First(X => X.Id == Id);

            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();

                return Ok("Cliente removido com sucesso !");
            }

            return BadRequest("Cliente não localizado !");
        }

        [HttpPut ("{Id}")]
        [Route("")]
        public IActionResult Put (Guid Id, Clientes dados)
        {
            var cliente = _context.Clientes.First(Y => Y.Id == Id);

            if (cliente != null)
            {
                cliente.Nome = string.IsNullOrEmpty(dados.Nome) ? cliente.Nome : dados.Nome;
                cliente.Idade = (dados.Idade <= 0) ? cliente.Idade : dados.Idade;
                cliente.Celular = string.IsNullOrEmpty(dados.Celular) ? cliente.Celular : dados.Celular;
                _context.Clientes.Update(cliente);
                _context.SaveChanges();


                return Ok(cliente);

            }

            return BadRequest("Não foi possivel atualizar as informações! ");
        }
    }
}
