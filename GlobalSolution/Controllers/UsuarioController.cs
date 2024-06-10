using GlobalSolution.Models;
using GlobalSolution.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepository.ListarTodos();
            return View(usuarios);
        }

        public IActionResult Detail(int id)
        {
            var usuario = _usuarioRepository.ObterUm(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(new UsuarioModel
            {
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento,
                Localizacao = usuario.Localizacao // Adiciona a localização ao modelo se existir
            });
        }



        [HttpGet] // Rota GET para exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Rota POST para lidar com a submissão do formulário de criação
        public IActionResult Create(UsuarioModel model)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepository.SalvarUsuario(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _usuarioRepository.ObterUm(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioModel = new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataNascimento = usuario.DataNascimento
            };

            // Salve a URL da página de detalhes do usuário na ViewBag para ser usada como redirecionamento após salvar
            ViewBag.ReturnUrl = Url.Action("Detail", "Usuario", new { id = id });

            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, UsuarioModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioRepository.EditarUsuario(model);

                    // Após salvar, redirecione para a página de usuários
                    return RedirectToAction("Index", "Usuario");
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


