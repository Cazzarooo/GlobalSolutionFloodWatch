using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Dados")]
        public string DadosSensor { get; set; }

        [Column("Localizacao")]
        public string LocalizacaoSensor { get; set; }

        // Relação muitos-para-muitos com Historico
        public virtual ICollection<Historico> Historicos { get; set; } = new List<Historico>();

        public virtual SistemaAlerta SistemaAlerta { get; set; }
    }
}
