using System.Collections.Generic;
using System.Linq;
using GlobalSolution.Models;

namespace GlobalSolution.Repository
{
    public interface ISistemaAlertaRepository
    {
        List<SistemaAlerta> ListarTodos();
        SistemaAlerta ObterUm(int id);
        SistemaAlerta SalvarSistemaAlerta(SistemaAlertaModel model);
        SistemaAlerta EditarSistemaAlerta(SistemaAlertaModel model);
    }
}

