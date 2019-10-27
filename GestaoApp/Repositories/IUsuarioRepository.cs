using GestaoApp.Models;

namespace GestaoApp.Repositories
{
    public interface IUsuarioRepository
    {
        void AddUser(Usuario usuario);
        Usuario VerificarUsuario(Usuario usuario);
    }
}