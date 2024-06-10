using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    public class Aplicativo
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int SistemaAlertaId { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Notificacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual SistemaAlerta SistemaAlerta { get; set; }
        

    }
}
