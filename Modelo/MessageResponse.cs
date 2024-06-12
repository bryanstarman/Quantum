using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Modelo
{
    public class MessageResponse
    {
        [JsonProperty("message")]
        public String mensaje { get; set; }
    }
}
