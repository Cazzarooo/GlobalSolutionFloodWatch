using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Repository
{
    public class SistemaAlertaRepository : ISistemaAlertaRepository
    {
        private readonly Contexto _context;

        public SistemaAlertaRepository(Contexto context)
        {
            _context = context;
        }

        public List<SistemaAlerta> ListarTodos()
        {
            return _context.SistemasAlerta
                           .Include(s => s.Sensor)
                           .ToList();
        }

        public SistemaAlerta ObterUm(int id)
        {
            return _context.SistemasAlerta
                           .Include(s => s.Sensor)
                           .FirstOrDefault(s => s.Id == id);
        }

        public SistemaAlerta SalvarSistemaAlerta(SistemaAlertaModel model)
        {
            var sistemaAlerta = new SistemaAlerta
            {
                SensorId = model.SensorId,
                TipoAlerta = model.TipoAlerta,
                Descricao = model.Descricao,
                DataHoraAlerta = model.DataHoraAlerta,
                NivelAlerta = model.NivelAlerta
            };

            _context.SistemasAlerta.Add(sistemaAlerta);
            _context.SaveChanges();

            return sistemaAlerta;
        }

        public SistemaAlerta EditarSistemaAlerta(SistemaAlertaModel model)
        {
            var sistemaAlerta = _context.SistemasAlerta.Find(model.Id);
            if (sistemaAlerta != null)
            {
                sistemaAlerta.SensorId = model.SensorId;
                sistemaAlerta.TipoAlerta = model.TipoAlerta;
                sistemaAlerta.Descricao = model.Descricao;
                sistemaAlerta.DataHoraAlerta = model.DataHoraAlerta;
                sistemaAlerta.NivelAlerta = model.NivelAlerta;

                _context.Entry(sistemaAlerta).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return sistemaAlerta;
        }
    }
}