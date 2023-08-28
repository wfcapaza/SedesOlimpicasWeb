using BusinessLogic;
using DataAccess;
using Entities;
using SedesOlimpicas.Helpers;
using SedesOlimpicas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SedesOlimpicas.Controllers
{
    [ValidarSesion]
    public class ComisarioController : Controller
    {
        private readonly IBLComisario _comisario;
        private readonly IBLEvento _evento;

        public ComisarioController(IBLComisario comisario, IBLEvento evento)
        {
            _comisario = comisario;
            _evento = evento;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListaComisarios()
        {
            List<Comisario> listaComisarios = await _comisario.ListaComisarios();
            List<ComisarioDto> listaComisariosDto = listaComisarios.Select(comisario => new ComisarioDto()
            {
                IdComisario = comisario.IdComisario,
                Nombres = comisario.Nombres,
                Apellidos = comisario.Apellidos,
                TipoTarea = comisario.TipoTarea,
                IdEvento = comisario.RefEvento.IdEvento,
                NombreEvento = comisario.RefEvento.NombreEvento
            }).ToList();
            return Json(listaComisariosDto, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CrearEditarComisario(int idComisario = 0)
        {
            List<Evento> listaEventos = await _evento.ListaEventos();
            ViewBag.ListEventos = listaEventos.Select(evento => new SelectListItem{
                Value = evento.IdEvento.ToString(),
                Text = evento.NombreEvento
            }).ToList();
            ViewBag.ListTipoTareas = new List<SelectListItem>() {
                new SelectListItem{ Value = "Juez", Text = "Juez" },
                new SelectListItem{ Value = "Observador", Text = "Observador" }
            };

            if (idComisario > 0)
            {
                Comisario comisario = await _comisario.ObtenerComisario(idComisario);
                ComisarioDto comisarioDto = new ComisarioDto()
                {
                    IdComisario = comisario.IdComisario,
                    Nombres = comisario.Nombres,
                    Apellidos = comisario.Apellidos,
                    TipoTarea = comisario.TipoTarea,
                    IdEvento = comisario.RefEvento.IdEvento
                };                
                return View(comisarioDto);
            }
            else
                return View(new ComisarioDto());
        }
        [HttpPost]
        public async Task<ActionResult> CrearEditarComisario(ComisarioDto comisarioDto)
        {
            if (!ModelState.IsValid)
                return View(comisarioDto);

            Comisario comisario = new Comisario()
            {
                IdComisario = comisarioDto.IdComisario,
                Nombres = comisarioDto.Nombres,
                Apellidos = comisarioDto.Apellidos,
                TipoTarea = comisarioDto.TipoTarea,
                RefEvento = new Evento() { IdEvento = comisarioDto.IdEvento }
            };

            if (comisario.IdComisario > 0)
                return Json(await _comisario.EditarComisario(comisario), JsonRequestBehavior.AllowGet);
            else
                return Json(await _comisario.CrearComisario(comisario), JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> EliminarComisario(int idComisario)
        {
            return Json(await _comisario.EliminarComisario(idComisario), JsonRequestBehavior.AllowGet);
        }
    }
}
