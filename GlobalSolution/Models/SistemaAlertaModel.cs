using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class SistemaAlertaModel
    {
        public int Id { get; set; }
        public int SensorId { get; set; }

        public int TipoAlerta { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        public DateTime DataHoraAlerta { get; set; }

        public int NivelAlerta { get; set; }
    }
}
