using GlobalSolution.Models;

namespace GlobalSolution.Repository
{
    public interface IAplicativoRepository
    {
        List<Aplicativo> ListarTodos();
        Aplicativo ObterUm(int id);
        Aplicativo SalvarAplicativo(AplicativoModel model);
        Aplicativo EditarAplicativo(AplicativoModel model);
    }
}
