using GlobalSolution.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GlobalSolution.Repository
{
    public class SensorRepository : ISensorRepository
    {
        private readonly Contexto _context;

        public SensorRepository(Contexto context)
        {
            _context = context;
        }

        public List<Sensor> ListarTodos()
        {
            return _context.Sensores
                           .Include(s => s.Historicos)
                           .ToList();
        }

        public Sensor ObterUm(int id)
        {
            return _context.Sensores
                           .Include(s => s.Historicos)
                           .FirstOrDefault(s => s.Id == id);
        }

        public Sensor SalvarSensor(SensorModel model)
        {
            var sensor = new Sensor
            {
                Id = model.IdSensor,
                DadosSensor = model.DadosSensor,
                LocalizacaoSensor = model.LocalizacaoSensor
            };

            _context.Sensores.Add(sensor);
            _context.SaveChanges();

            return sensor;
        }

        public Sensor EditarSensor(SensorModel model)
        {
            var sensor = _context.Sensores.Find(model.IdSensor);
            if (sensor != null)
            {
                sensor.DadosSensor = model.DadosSensor;
                sensor.LocalizacaoSensor = model.LocalizacaoSensor;

                _context.Entry(sensor).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return sensor;
        }
    }
}
