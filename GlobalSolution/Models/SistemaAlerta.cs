using System;

namespace GlobalSolution.Models
{
    public class SistemaAlerta
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public int TipoAlerta { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraAlerta { get; set; }
        public int NivelAlerta { get; set; }

        public virtual Sensor Sensor { get; set; }

    }
}
