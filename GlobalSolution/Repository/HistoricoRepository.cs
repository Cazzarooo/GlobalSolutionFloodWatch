using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Repository
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly Contexto _context;

        public HistoricoRepository(Contexto context)
        {
            _context = context;
        }
        public List<Historico> ListarTodos()
        {
            return _context.Historicos.ToList();
        }

        public Historico ObterUm(int id)
        {
            return _context.Historicos.FirstOrDefault(h => h.Id == id);
        }

        public Historico SalvarHistorico(HistoricoModel model)
        {
            var historico = new Historico
            {
                ArmazenamentoDados = model.ArmazenamentoDados,
                TipoDados = model.TipoDados,
                AnoDados = model.AnoDados
            };

            _context.Historicos.Add(historico);
            _context.SaveChanges();

            return historico;
        }

        public Historico EditarHistorico(HistoricoModel model)
        {
            var historico = _context.Historicos.Find(model.Id);
            if (historico != null)
            {
                historico.ArmazenamentoDados = model.ArmazenamentoDados;
                historico.TipoDados = model.TipoDados;
                historico.AnoDados = model.AnoDados;

                _context.Entry(historico).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return historico;
        }
    }
}
    

