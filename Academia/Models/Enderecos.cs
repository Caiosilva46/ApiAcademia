using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Enderecos
    {
        public Guid Id { get; set; }

        public string Rua { get; set; }
    
        public int Numero { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public Enderecos()
        {
            Id = Guid.NewGuid();
        }

    }
}
