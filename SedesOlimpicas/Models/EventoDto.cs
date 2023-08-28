using System.ComponentModel.DataAnnotations;

namespace SedesOlimpicas.Models
{
    public class EventoDto
    {
        public int IdEvento { get; set; }
        [Required(ErrorMessage ="Nombre es requerido")]
        public string NombreEvento { get; set; }
        [Required(ErrorMessage = "Fecha es requerido")]
        public string Fecha { get; set; }
        [Required(ErrorMessage = "Duración es requerido")]
        public int Duracion { get; set; }
        [Required(ErrorMessage = "Nro. de participantes es requerido")]
        public int NroParticipantes { get; set; }
        [Required(ErrorMessage = "Nro. de comisarios es requerido")]
        public int NroComisarios { get; set; }
        public int IdComplejo { get; set; }
        public string NombreComplejo { get; set; }
    }
}