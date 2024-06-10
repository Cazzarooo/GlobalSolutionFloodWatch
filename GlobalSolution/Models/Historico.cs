using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    public class Historico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ArmazenamentoDados { get; set; }
        public string TipoDados { get; set; }
        public int AnoDados { get; set; }

        // Relação muitos-para-muitos com Sensor
        public virtual ICollection<Sensor> Sensores { get; set; } = new List<Sensor>();
    }
}
