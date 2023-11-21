using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioV2.Clases
{
    internal class Direccion
    {
        public Direccion()
        {
        }
        public Direccion(int id, string calle, string colonia, string numero, string codigoPostal, string estado, string pais)
        {
            Id = id;
            Calle = calle;
            Colonia = colonia;
            Numero = numero;
            CodigoPostal = codigoPostal;
            Estado = estado;
        }
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }

        public string Numero { get; set; }

        public string CodigoPostal { get; set; }

        public string Estado { get; set; }
    }
}
