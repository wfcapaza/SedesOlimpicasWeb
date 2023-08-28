using System.ComponentModel.DataAnnotations;

namespace SedesOlimpicas.Models
{
    public class SedeDto
    {
        public int IdSede { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int NroComplejos { get; set; }
        [Required]
        public decimal Presupuesto { get; set; }
    }
}