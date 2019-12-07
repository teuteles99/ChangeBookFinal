using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangeBook.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Nome_livro { get; set; }
        public string Editora { get; set; }
        public long Isbn { get; set; }
        public string Autor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_compra { get; set; }
        public string Edicao { get; set; }
        public bool Disponibilidade { get; set; }

        //Relacionamento com a tabela Usuario
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        //Relacionamento com a tabela Genero
        public int GeneroId { get; set; }
        public Genero Genero{ get; set; }

    }
}
