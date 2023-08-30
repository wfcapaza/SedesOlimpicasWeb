using SedesOlimpicas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SedesOlimpicas.Controllers
{
    [ValidarSesion]
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PaginaNoEncontrada()
        {
            return View();
        }
    }
}