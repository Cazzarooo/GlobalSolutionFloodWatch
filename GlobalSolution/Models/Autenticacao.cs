using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GlobalSolution.Models
{
    [Table("TB_AUTENTICACAO")]
    public class Autenticacao
    {
        internal readonly int Id;

        [Key]
        [Column("id_usuario")]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Column("email_usuario")]
        [StringLength(100)]
        public string EmailUsuario { get; set; }

        [Column("senha_usuario")]
        [StringLength(50)]
        public string SenhaUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
