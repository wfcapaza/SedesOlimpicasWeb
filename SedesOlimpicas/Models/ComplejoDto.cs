using System.ComponentModel.DataAnnotations;

namespace SedesOlimpicas.Models
{
    public class ComplejoDto
    {
        public int IdComplejo { get; set; }
        [Required]
        public string NombreComplejo { get; set; }
        [Required]
        public string Localizacion { get; set; }
        [Required]
        public string Jefe { get; set; }
        [Required]
        public string TipoDeporte { get; set; }
        [Required]
        public decimal AreaOcupada { get; set; }
        [Required]
        public int IdSede { get; set; }
        public string NombreSede { get; set; }
    }
}