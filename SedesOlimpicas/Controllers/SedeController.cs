using BusinessLogic;
using Entities;
using SedesOlimpicas.Helpers;
using SedesOlimpicas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SedesOlimpicas.Controllers
{
    [ValidarSesion]
    public class SedeController : Controller
    {
        private readonly IBLSede _sede;

        public SedeController(IBLSede sede)
        {
            _sede = sede;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListaSedes()
        {
            List<Sede> listaSedes = await _sede.ListaSedes();
            List<SedeDto> listaSedesDto = listaSedes.Select(sede => new SedeDto()
            {
                IdSede = sede.IdSede,
                Nombre = sede.Nombre,
                NroComplejos = sede.NroComplejos,
                Presupuesto = sede.Presupuesto
            }).ToList();
            return Json(listaSedesDto, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CrearEditarSede(int idSede = 0)
        {
            if (idSede > 0)
            {
                Sede sede = await _sede.ObtenerSede(idSede);
                SedeDto sedeDto = new SedeDto()
                {
                    IdSede = sede.IdSede,
                    Nombre = sede.Nombre,
                    NroComplejos = sede.NroComplejos,
                    Presupuesto = sede.Presupuesto
                };
                return View(sedeDto);
            }
            else
                return View(new SedeDto());
        }
        [HttpPost]
        public async Task<ActionResult> CrearEditarSede(SedeDto sedeDto)
        {
            if (!ModelState.IsValid)
                return View(sedeDto);

            Sede sede = new Sede()
            {
                IdSede = sedeDto.IdSede,
                Nombre = sedeDto.Nombre,
                NroComplejos = sedeDto.NroComplejos,
                Presupuesto = sedeDto.Presupuesto
            };

            if (sede.IdSede > 0)
                return Json(await _sede.EditarSede(sede), JsonRequestBehavior.AllowGet);
            else
                return Json(await _sede.CrearSede(sede), JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> EliminarSede(int idSede)
        {
            return Json(await _sede.EliminarSede(idSede), JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> ValidarNombreSede(string nombreSede)
        {
            return Json(await _sede.ValidarNombreSede(nombreSede), JsonRequestBehavior.AllowGet);
        }
    }
}