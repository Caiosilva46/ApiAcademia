using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Models
{
    public class Treinos
    {

        public Guid Id { get; set; }

        public string NomeSerie { get; set; }
        public string ParteCorpo { get; set; }

        public int QuantidadeSerie { get; set; }

        public int Repeticoes { get; set; }


        public Treinos()
        {

            Id = Guid.NewGuid();

        }

    }
}
