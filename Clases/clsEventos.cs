using Examen_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_3.Clases
{
    public class clsEventos
    {

        private NatilleraEntities2 db = new NatilleraEntities2();

        public Evento evento { get; set; }

        public string Insertar()
        {
            try
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
                return "Evento registrado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al registrar: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Evento eventoExistente = db.Eventos.FirstOrDefault(e => e.idEventos == evento.idEventos);
                if (eventoExistente == null)
                    return "Evento no encontrado.";

                eventoExistente.TipoEvento = evento.TipoEvento;
                eventoExistente.NombreEvento = evento.NombreEvento;
                eventoExistente.TotalIngreso = evento.TotalIngreso;
                eventoExistente.FechaEvento = evento.FechaEvento;
                eventoExistente.Sede = evento.Sede;
                eventoExistente.ActiviadesPlaneadas = evento.ActiviadesPlaneadas;

                db.SaveChanges();
                return "Evento actualizado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al actualizar: " + ex.Message;
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                Evento eventoExistente = db.Eventos.FirstOrDefault(e => e.idEventos == id);
                if (eventoExistente == null)
                    return "Evento no encontrado.";

                db.Eventos.Remove(eventoExistente);
                db.SaveChanges();
                return "Evento eliminado correctamente.";
            }
            catch (Exception ex)
            {
                return "Error al eliminar: " + ex.Message;
            }
        }

        public List<Evento> ConsultarPorTipo(string tipo)
        {
            return db.Eventos.Where(e => e.TipoEvento.Contains(tipo)).ToList();
        }

        public List<Evento> ConsultarPorNombre(string nombre)
        {
            return db.Eventos.Where(e => e.NombreEvento.Contains(nombre)).ToList();
        }

        public List<Evento> ConsultarPorFecha(DateTime fecha)
        {
            return db.Eventos.Where(e => e.FechaEvento == fecha).ToList();
        }
    }

}