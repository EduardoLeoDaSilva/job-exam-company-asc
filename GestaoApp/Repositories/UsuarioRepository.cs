using GestaoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoApp.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationContext _context;
        public UsuarioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddUser(Usuario usuario)
        {
            if (usuario != null)
            {
                _context.Set<Usuario>().Add(usuario);
                _context.SaveChanges();
                return;
            }
            throw new ArgumentNullException($"Argumento informado {nameof(usuario)} é nulo");
        }

        public Usuario VerificarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                var usuarioBd = _context.Set<Usuario>().Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha).SingleOrDefault();
                if (usuarioBd == null)
                {
                    throw new Exception("O usuario não existe na base de dados do sistema");
                }
                return usuarioBd;
            }
            throw new ArgumentNullException($"Argumento informado {nameof(usuario)} é nulo");

        }

    }
}
