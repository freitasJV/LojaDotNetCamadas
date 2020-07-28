using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DTO
{
    public class usuario_DTO
    {
        public int Cod_usuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime Cadastro { get; set; }
        public string Situacao { get; set; }
        public int Perfil { get; set; }
    }
}
