using System;
using System.ComponentModel.DataAnnotations;
namespace GlobalSolution.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [StringLength(100)]
        public string Localizacao { get; set; }
    }
}
