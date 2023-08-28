using BusinessLogic;
using Entities;
using SedesOlimpicas.Helpers;
using SedesOlimpicas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;
using DataAccess;

namespace SedesOlimpicas.Controllers
{
    [ValidarSesion]
    public class EventoController : Controller
    {
        private readonly IBLEvento _evento;
        private readonly IBLComplejo _complejo;

        public EventoController(IBLEvento evento, IBLComplejo complejo)
        {
            _evento = evento;
            _complejo = complejo;
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> ListaEventos()
        {
            List<Evento> listaEventos = await _evento.ListaEventos();
            List<EventoDto> listaEventosDto = listaEventos.Select(evento => new EventoDto()
            {
                IdEvento = evento.IdEvento,
                NombreEvento = evento.NombreEvento,
                Fecha = evento.Fecha,
                Duracion = evento.Duracion,
                NroParticipantes = evento.NroParticipantes,
                NroComisarios = evento.NroComisarios,
                IdComplejo = evento.RefComplejo.IdComplejo,
                NombreComplejo = evento.RefComplejo.NombreComplejo
            }).ToList();
            return Json(listaEventosDto, JsonRequestBehavior.AllowGet);
        }
        public async Task<JsonResult> EliminarEvento(int idEvento)
        {
            return Json(await _evento.EliminarEvento(idEvento), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> CrearEditarEvento(int idEvento = 0)
        {
            List<Complejo> listaComplejos = await _complejo.ListaComplejos();
            ViewBag.ListaComplejos = listaComplejos.Select(sede => new SelectListItem
            {
                Value = sede.IdComplejo.ToString(),
                Text = sede.NombreComplejo
            }).ToList();

            if (idEvento > 0)
            {
                Evento evento = await _evento.ObtenerEvento(idEvento);
                EventoDto eventoDto = new EventoDto()
                {
                    IdEvento = evento.IdEvento,
                    NombreEvento = evento.NombreEvento,
                    Fecha = evento.Fecha,
                    Duracion = evento.Duracion,
                    NroParticipantes = evento.NroParticipantes,
                    NroComisarios = evento.NroComisarios,
                    IdComplejo = evento.RefComplejo.IdComplejo
                };
                return View(eventoDto);
            }                
            else
                return View(new EventoDto());
        }
        [HttpPost]
        public async Task<ActionResult> CrearEditarEvento(EventoDto eventoDto)
        {
            if (!ModelState.IsValid)
                return View(eventoDto);

            Evento evento = new Evento()
            {
                IdEvento = eventoDto.IdEvento,
                NombreEvento = eventoDto.NombreEvento,
                Fecha = eventoDto.Fecha,
                Duracion = eventoDto.Duracion,
                NroParticipantes = eventoDto.NroParticipantes,
                NroComisarios = eventoDto.NroComisarios,
                RefComplejo = new Complejo() { IdComplejo = eventoDto.IdComplejo}
            };

            if (evento.IdEvento > 0)
                return Json(await _evento.EditarEvento(evento), JsonRequestBehavior.AllowGet);
            else
                return Json(await _evento.CrearEvento(evento), JsonRequestBehavior.AllowGet);
        }

    }
}