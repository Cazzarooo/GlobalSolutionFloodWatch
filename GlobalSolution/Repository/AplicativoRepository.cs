using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Repository
{
    public class AplicativoRepository : IAplicativoRepository
    {
        private readonly Contexto _context;
        public AplicativoRepository(Contexto context)
        {
            _context = context;
        }
        public List<Aplicativo> ListarTodos()
        {
            return _context.Aplicativos
                           .Include(a => a.Usuario)
                           .Include(a => a.SistemaAlerta)
                           .ToList();
        }

        public Aplicativo ObterUm(int id)
        {
            return _context.Aplicativos
                           .Include(a => a.Usuario)
                           .Include(a => a.SistemaAlerta)
                           .FirstOrDefault(a => a.Id == id);
        }

        public Aplicativo SalvarAplicativo(AplicativoModel model)
        {
            var aplicativo = new Aplicativo
            {
                UsuarioId = model.UsuarioId,
                SistemaAlertaId = model.SistemaAlertaId,
                NomeUsuario = model.NomeUsuario,
                Senha = model.Senha,
                Notificacao = model.Notificacao
            };

            _context.Aplicativos.Add(aplicativo);
            _context.SaveChanges();

            return aplicativo;
        }

        public Aplicativo EditarAplicativo(AplicativoModel model)
        {
            var aplicativo = _context.Aplicativos.Find(model.Id);
            if (aplicativo != null)
            {
                aplicativo.UsuarioId = model.UsuarioId;
                aplicativo.SistemaAlertaId = model.SistemaAlertaId;
                aplicativo.NomeUsuario = model.NomeUsuario;
                aplicativo.Senha = model.Senha;
                aplicativo.Notificacao = model.Notificacao;

                _context.Entry(aplicativo).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return aplicativo;
        }
    }
}