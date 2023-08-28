using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comisario
    {
        public int IdComisario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string TipoTarea { get; set; }
        public Evento RefEvento { get; set; }
    }
}
