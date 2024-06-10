namespace GlobalSolution.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SensorModel
    {
        public int IdSensor { get; set; }
        public int Id { get; set; }

        [StringLength(500)]
        public string DadosSensor { get; set; }

        [StringLength(100)]
        public string LocalizacaoSensor { get; set; }
    }
}
