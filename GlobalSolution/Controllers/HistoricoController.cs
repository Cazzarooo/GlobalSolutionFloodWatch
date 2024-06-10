using GlobalSolution.Models;
using GlobalSolution.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GlobalSolution.Controllers
{
    public class HistoricoController : Controller
    {
        private readonly IHistoricoRepository _historicoRepository;

        public HistoricoController(IHistoricoRepository historicoRepository)
        {
            _historicoRepository = historicoRepository;
        }

        public IActionResult Index()
        {
            var historicos = _historicoRepository.ListarTodos();
            var historicosModel = historicos.Select(historico => new HistoricoModel
            {
                Id = historico.Id,
                ArmazenamentoDados = historico.ArmazenamentoDados,
                TipoDados = historico.TipoDados,
                AnoDados = historico.AnoDados
            });
            return View(historicosModel);
        }

        // GET: Historico/Detail/5
        public IActionResult Detail(int id)
        {
            var historico = _historicoRepository.ObterUm(id);
            if (historico == null)
            {
                return NotFound();
            }

            return View(new HistoricoModel
            {
                ArmazenamentoDados = historico.ArmazenamentoDados,
                TipoDados = historico.TipoDados,
                AnoDados = historico.AnoDados
            });
        }


        [HttpGet] // Rota GET para exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Rota POST para lidar com a submissão do formulário de criação
        public IActionResult Create(HistoricoModel model)
        {
            if (ModelState.IsValid)
            {
                _historicoRepository.SalvarHistorico(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Historico/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historico = _historicoRepository.ObterUm(id.Value);

            if (historico == null)
            {
                return NotFound();
            }

            var historicoModel = new HistoricoModel
            {
                Id = historico.Id,
                ArmazenamentoDados = historico.ArmazenamentoDados,
                TipoDados = historico.TipoDados,
                AnoDados = historico.AnoDados
            };

            // Salve a URL da página de detalhes do histórico na ViewBag para ser usada como redirecionamento após salvar
            ViewBag.ReturnUrl = Url.Action("Detail", "Historico", new { id = id });

            return View(historicoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HistoricoModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _historicoRepository.EditarHistorico(model);

                    // Após salvar, redirecione para a página de históricos
                    return RedirectToAction("Index", "Historico");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao tentar salvar as alterações.");
                    // Adicione logs ou tratamento de erro adicional, se necessário
                }
            }

            // Se houver erros de validação ou se a edição falhar, retorne à página de edição
            return View(model);
        }


    }
}
