using System.Collections.Generic;
using System.Linq;
using GlobalSolution.Models;
namespace GlobalSolution.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodos();
        Usuario ObterUm(int id);
        Usuario SalvarUsuario(UsuarioModel model);
        Usuario EditarUsuario(UsuarioModel model);

    }
}
