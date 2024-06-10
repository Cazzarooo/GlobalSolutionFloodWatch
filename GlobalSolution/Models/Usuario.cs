using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalSolution.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("nome_usuario")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Column("data_nascimento_usuario")]
        public DateTime DataNascimento { get; set; }

        [Column("localizacao_usuario")]
        [StringLength(100)]
        public string Localizacao { get; set; }

        public virtual ICollection<Autenticacao> Autenticacoes { get; set; }
        public virtual ICollection<Aplicativo> Aplicativos { get; set; }
    }
}
