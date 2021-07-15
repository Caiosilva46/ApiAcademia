using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Clientes
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public string Celular { get; set; }

        public Clientes()
        {

            Id = Guid.NewGuid();

        }
    }
}
