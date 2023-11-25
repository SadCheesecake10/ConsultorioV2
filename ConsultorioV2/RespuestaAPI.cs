using ConsultorioV2.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsultorioV2
{
    internal class RespuestaAPI
    {
        [JsonProperty("error")]
        public bool error { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("codigo_postal")]
        public Direccion direccion { get; set; }
    }
}
