using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class HistoricoModel
    {
        public int Id { get; set; }

        [StringLength(500)]
        public string ArmazenamentoDados { get; set; }

        [StringLength(50)]
        public string TipoDados { get; set; }

        public int AnoDados { get; set; }

    }
}
