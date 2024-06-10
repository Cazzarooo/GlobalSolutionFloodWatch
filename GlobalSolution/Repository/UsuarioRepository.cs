using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _context;

        public UsuarioRepository(Contexto context)
        {
            _context = context;
        }


        public List<Usuario> ListarTodos()
        {
            return _context.Usuarios
                           .Include(u => u.Autenticacoes)
                           .Include(u => u.Aplicativos)
                           .ToList();
        }

        public Usuario ObterUm(int id)
        {
            return _context.Usuarios
                           .Include(u => u.Autenticacoes)
                           .Include(u => u.Aplicativos)
                           .FirstOrDefault(u => u.Id == id);
        }

        public Usuario SalvarUsuario(UsuarioModel model)
        {
            var usuario = new Usuario
            {
                Nome = model.Nome,
                DataNascimento = model.DataNascimento,
                Localizacao = model.Localizacao
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario EditarUsuario(UsuarioModel model)
        {
            var usuario = _context.Usuarios.Find(model.Id);
            if (usuario != null)
            {
                usuario.Nome = model.Nome;
                usuario.DataNascimento = model.DataNascimento;
                usuario.Localizacao = model.Localizacao;

                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return usuario;
        }
    }
}


