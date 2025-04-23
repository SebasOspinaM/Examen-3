using Examen_3.Clases;
using Examen_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen_3.Controllers
{
    [RoutePrefix("api/Eventos")]
    [Authorize]
    public class EventosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Evento evento)
        {
            clsEventos cls = new clsEventos();
            cls.evento = evento;
            return cls.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Evento evento)
        {
            clsEventos cls = new clsEventos();
            cls.evento = evento;
            return cls.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar(int id)
        {
            clsEventos cls = new clsEventos();
            return cls.Eliminar(id);
        }

        [HttpGet]
        [Route("ConsultarPorTipo")]
        public List<Evento> ConsultarPorTipo(string tipo)
        {
            clsEventos cls = new clsEventos();
            return cls.ConsultarPorTipo(tipo);
        }

        [HttpGet]
        [Route("ConsultarPorNombre")]
        public List<Evento> ConsultarPorNombre(string nombre)
        {
            clsEventos cls = new clsEventos();
            return cls.ConsultarPorNombre(nombre);
        }

        [HttpGet]
        [Route("ConsultarPorFecha")]
        public List<Evento> ConsultarPorFecha(DateTime fecha)
        {
            clsEventos cls = new clsEventos();
            return cls.ConsultarPorFecha(fecha);
        }
    }

}