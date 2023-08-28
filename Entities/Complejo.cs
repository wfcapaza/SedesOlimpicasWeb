namespace Entities
{
    public class Complejo
    {
        public int IdComplejo { get; set; }
        public string NombreComplejo { get; set; }
        public string Localizacion { get; set; }
        public string Jefe { get; set; }
        public string TipoDeporte { get; set; }
        public decimal AreaOcupada { get; set; }
        public Sede RefSede { get; set; }
    }
}
