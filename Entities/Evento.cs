namespace Entities
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public string Fecha { get; set; }
        public int Duracion { get; set; }
        public int NroParticipantes { get; set; }
        public int NroComisarios { get; set; }
        public Complejo RefComplejo { get; set; }
    }
}
