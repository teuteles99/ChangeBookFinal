using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeBook.Models
{
    public class Chamado
    {
        public int ChamadoId { get; set; }
        public string Descricao { get; set; }
        public string Login { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
