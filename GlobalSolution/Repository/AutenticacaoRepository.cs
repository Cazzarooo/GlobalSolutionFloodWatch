using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Repository
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly Contexto _context;

        public AutenticacaoRepository(Contexto context)
        {
            _context = context;
        }
        public List<Autenticacao> ListarTodos()
        {
            return _context.Autenticacoes
                           .Include(a => a.Usuario)
                           .ToList();
        }

        public Autenticacao ObterUm(int id)
        {
            return _context.Autenticacoes
                           .Include(a => a.Usuario)
                           .FirstOrDefault(a => a.UsuarioId == id);
        }

        public Autenticacao SalvarAutenticacao(AutenticacaoModel model)
        {
            var autenticacao = new Autenticacao
            {
                EmailUsuario = model.EmailUsuario,
                SenhaUsuario = model.SenhaUsuario,
                UsuarioId = model.UsuarioId
            };

            _context.Autenticacoes.Add(autenticacao);
            _context.SaveChanges();

            return autenticacao;
        }

        public Autenticacao EditarAutenticacao(AutenticacaoModel model)
        {
            var autenticacao = _context.Autenticacoes.Find(model.UsuarioId);
            if (autenticacao != null)
            {
                autenticacao.EmailUsuario = model.EmailUsuario;
                autenticacao.SenhaUsuario = model.SenhaUsuario;
                autenticacao.UsuarioId = model.UsuarioId;

                _context.Entry(autenticacao).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return autenticacao;
        }
    }
}
    

