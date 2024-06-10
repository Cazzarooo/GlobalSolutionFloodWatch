using GlobalSolution.Models;
using GlobalSolution.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GlobalSolution.Controllers
{
    public class SensorController : Controller
    {
        private readonly ISensorRepository _sensorRepository;

        public SensorController(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        public IActionResult Index()
        {
            var sensores = _sensorRepository.ListarTodos();
            var sensorModels = sensores.Select(sensor => new SensorModel
            {
                IdSensor = sensor.Id,
                Id = sensor.Id,
                DadosSensor = sensor.DadosSensor,
                LocalizacaoSensor = sensor.LocalizacaoSensor
            });
            return View(sensorModels);
        }

        // GET: Sensor/Detail/5
        public IActionResult Detail(int id)
        {
            var sensor = _sensorRepository.ObterUm(id);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(new SensorModel
            {
                IdSensor = sensor.Id,
                Id = sensor.Id,
                DadosSensor = sensor.DadosSensor,
                LocalizacaoSensor = sensor.LocalizacaoSensor
            });
        }


        [HttpGet] // Rota GET para exibir o formulário de criação
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Rota POST para lidar com a submissão do formulário de criação
        public IActionResult Create(SensorModel model)
        {
            if (ModelState.IsValid)
            {
                _sensorRepository.SalvarSensor(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Sensor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = _sensorRepository.ObterUm(id.Value);

            if (sensor == null)
            {
                return NotFound();
            }

            var sensorModel = new SensorModel
            {
                IdSensor = sensor.Id,
                Id = sensor.Id,
                DadosSensor = sensor.DadosSensor,
                LocalizacaoSensor = sensor.LocalizacaoSensor
            };

            // Salve a URL da página de detalhes do sensor na ViewBag para ser usada como redirecionamento após salvar
            ViewBag.ReturnUrl = Url.Action("Detail", "Sensor", new { id = id });

            return View(sensorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SensorModel model)
        {
            if (id != model.IdSensor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _sensorRepository.EditarSensor(model);

                    // Após salvar, redirecione para a página de sensores
                    return RedirectToAction("Index", "Sensor");
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
