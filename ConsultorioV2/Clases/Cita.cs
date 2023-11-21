using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioV2.Clases
{
    internal class Cita
    {
        public Cita() 
        { 
        }
        public Cita(int id, DateTime fecha, string hora, string tipo_Cita)
        {
            Id = id;
            Fecha = fecha;
            Hora = hora;
            Tipo_Cita = tipo_Cita;
        }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Tipo_Cita { get; set; }
    }
}
