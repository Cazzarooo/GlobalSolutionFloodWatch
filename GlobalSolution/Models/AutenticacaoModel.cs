using System.ComponentModel.DataAnnotations;

namespace GlobalSolution.Models
{
    public class AutenticacaoModel
    {
        public int UsuarioId { get; set; }

        [Required, StringLength(100)]
        public string EmailUsuario { get; set; }

        [Required, StringLength(50)]
        public string SenhaUsuario { get; set; }
    }
}
