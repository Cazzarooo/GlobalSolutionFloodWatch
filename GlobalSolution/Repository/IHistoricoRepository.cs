using System.Collections.Generic;
using System.Linq;
using GlobalSolution.Models;

namespace GlobalSolution.Repository
{
    public interface IHistoricoRepository
    {
        List<Historico> ListarTodos();
        Historico ObterUm(int id);
        Historico SalvarHistorico(HistoricoModel model);
        Historico EditarHistorico(HistoricoModel model);
    }
}
