using BusinessLogic;
using Entities;
using SedesOlimpicas.Helpers;
using SedesOlimpicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SedesOlimpicas.Controllers
{
    [ValidarSesion]
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IBLComisario _comisario;

        public HomeController(IBLComisario comisario)
        {
            _comisario = comisario;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListaSedeConComisario()
        {
            return Json(await _comisario.ListaSedeConComisario(), JsonRequestBehavior.AllowGet);
        }
    }
}