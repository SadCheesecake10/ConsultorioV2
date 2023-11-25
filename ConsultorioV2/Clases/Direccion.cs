using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsultorioV2.Clases
{
    internal class Direccion
    {
        [JsonProperty("estado")]
        public string estado { get; set; }
        [JsonProperty("estado_abreviatura")]
        public string estado_abreviatura { get; set; }
        [JsonProperty("municipio")]
        public string municipio { get; set; }
        [JsonProperty("colonias")]
        public List<string> colonias { get; set; }
    }
}
