using BusinessLogic;
using SedesOlimpicas.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SedesOlimpicas.Controllers
{
    public class LoginController : Controller
    {
        private IBLUsuario _business;
        public LoginController(IBLUsuario business)
        {
            _business = business;
        }
        [HttpGet]
        public ActionResult InicioSesion()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> InicioSesion(UsuarioDto modelo)
        {
            if(!ModelState.IsValid)
                return View(modelo);

            modelo.Contrasenha = Utils.ConvertirSha256(modelo.Contrasenha);
            var usuario = await _business.ObtenerUsuario(modelo.CorreoElectronico, modelo.Contrasenha);

            if (usuario == null)
                return View("InicioSesion");

            Session["Usuario"] = usuario;
            return RedirectToAction("Index", "Sede");
        }
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            return RedirectToAction("InicioSesion", "Login");
        }
    }
}