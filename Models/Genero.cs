using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeBook.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Nome { get; set; }

        public List<Livro> Livros { get; set; }
    }
}
