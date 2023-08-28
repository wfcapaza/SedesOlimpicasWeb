using System.ComponentModel.DataAnnotations;

namespace SedesOlimpicas.Models
{
    public class ComisarioDto
    {
        public int IdComisario { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string TipoTarea { get; set; }
        [Required]
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
    }
}