using System.Collections.Generic;
using System.Linq;
using GlobalSolution.Models;

namespace GlobalSolution.Repository
{
    public interface IAutenticacaoRepository
    {
        List<Autenticacao> ListarTodos();
        Autenticacao ObterUm(int id);
        Autenticacao SalvarAutenticacao(AutenticacaoModel model);
        Autenticacao EditarAutenticacao(AutenticacaoModel model);
    }
}
