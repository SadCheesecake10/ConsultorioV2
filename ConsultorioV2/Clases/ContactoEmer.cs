using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioV2.Clases
{
    internal class ContactoEmer
    {
        public ContactoEmer()
        {
        }
        public ContactoEmer(int id, string nombre, string apellidoPaterno, string apellidoMaterno, int telefono , string parentesco)
        {
            Id = id;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Telefono = telefono;
            Parentesco = parentesco;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", Nombre, ApellidoPaterno, ApellidoMaterno);
            }
        }
        public int Telefono { get; set; }
        public string Parentesco { get; set; }
    }
}
