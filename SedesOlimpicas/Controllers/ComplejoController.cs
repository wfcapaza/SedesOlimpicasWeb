using BusinessLogic;
using DataAccess;
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
    public class ComplejoController : Controller
    {
        private readonly IBLComplejo _complejo;
        private readonly IBLSede _sede;

        public ComplejoController(IBLComplejo complejo, IBLSede sede)
        {
            _complejo = complejo;
            _sede = sede;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListaComplejos()
        {
            List<Complejo> listaComplejos = await _complejo.ListaComplejos();
            List<ComplejoDto> listaComplejosDto = listaComplejos.Select(complejo => new ComplejoDto()
            {
                IdComplejo = complejo.IdComplejo,
                NombreComplejo = complejo.NombreComplejo,
                Localizacion = complejo.Localizacion,
                Jefe = complejo.Jefe,
                TipoDeporte = complejo.TipoDeporte,
                AreaOcupada = complejo.AreaOcupada,
                IdSede = complejo.RefSede.IdSede,
                NombreSede = complejo.RefSede.Nombre
            }).ToList();
            return Json(listaComplejosDto, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CrearEditarComplejo(int idComplejo = 0)
        {
            List<Sede> listaSedes = await _sede.ListaSedes();
            ViewBag.ListSedes = listaSedes.Select(sede => new SelectListItem
            {
                Value = sede.IdSede.ToString(),
                Text = sede.Nombre
            }).ToList();
            ViewBag.ListTipoDepo = new List<SelectListItem>() {
                new SelectListItem{ Value = "Unico Deporte", Text = "Unico Deporte" },
                new SelectListItem{ Value = "Polideporte", Text = "Polideporte" }
            };

            if (idComplejo > 0)
            {
                Complejo complejo = await _complejo.ObtenerComplejo(idComplejo);
                ComplejoDto complejoDto = new ComplejoDto()
                {
                    IdComplejo = complejo.IdComplejo,
                    NombreComplejo = complejo.NombreComplejo,
                    Localizacion = complejo.Localizacion,
                    Jefe = complejo.Jefe,
                    TipoDeporte = complejo.TipoDeporte,
                    AreaOcupada = complejo.AreaOcupada,
                    IdSede = complejo.RefSede.IdSede,
                    NombreSede = complejo.RefSede.Nombre
                };
                return View(complejoDto);
            }
            else
                return View(new ComplejoDto());
        }
        [HttpPost]
        public async Task<ActionResult> CrearEditarComplejo(ComplejoDto complejoDto)
        {
            if (!ModelState.IsValid)
                return View(complejoDto);

            Complejo complejo = new Complejo()
            {
                IdComplejo = complejoDto.IdComplejo,
                NombreComplejo = complejoDto.NombreComplejo,
                Localizacion = complejoDto.Localizacion,
                Jefe = complejoDto.Jefe,
                TipoDeporte = complejoDto.TipoDeporte,
                AreaOcupada = complejoDto.AreaOcupada,
                RefSede = new Sede() { IdSede = complejoDto.IdSede}
            };

            if (complejo.IdComplejo > 0)
                return Json(await _complejo.EditarComplejo(complejo), JsonRequestBehavior.AllowGet);
            else
                return Json(await _complejo.CrearComplejo(complejo), JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> EliminarComplejo(int idComplejo)
        {
            return Json(await _complejo.EliminarComplejo(idComplejo), JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> ValidarNroMaxSedes(int idSede)
        {
            return Json(await _complejo.ValidarNroMaxSedes(idSede), JsonRequestBehavior.AllowGet);
        }
    }
}