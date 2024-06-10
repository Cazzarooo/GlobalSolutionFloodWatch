using System.Collections.Generic;
using System.Linq;
using GlobalSolution.Models;

namespace GlobalSolution.Repository
{
    public interface ISensorRepository
    {
        List<Sensor> ListarTodos();
        Sensor ObterUm(int id);
        Sensor SalvarSensor(SensorModel model);
        Sensor EditarSensor(SensorModel model);
    }
}
