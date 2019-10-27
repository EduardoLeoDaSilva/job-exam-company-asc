using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(int usuarioId, string nome, string email, string senha)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
