using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SedesOlimpicas.Models
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "Correo electronico es requerido")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "Contraseña es requerida")]
        public string Contrasenha { get; set; }
    }
}