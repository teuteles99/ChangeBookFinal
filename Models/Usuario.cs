using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeBook.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public bool Admin { get; set; }
        public List<Livro> Livros { get; set; }
        public List<Chamado> Chamados { get; set; }
    }
}
