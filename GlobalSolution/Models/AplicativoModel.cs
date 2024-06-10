using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class AplicativoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int SistemaAlertaId { get; set; }

        [Required, StringLength(50)]
        public string NomeUsuario { get; set; }

        [Required, StringLength(50)]
        public string Senha { get; set; }

        [StringLength(100)]
        public string Notificacao { get; set; }
    }
}
