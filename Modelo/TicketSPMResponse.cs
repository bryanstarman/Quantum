using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Modelo
{
    class TicketSPMResponse
    {
        [JsonProperty("data")]
        public List<Data> Datas { get; set; }
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
    }
    public class Data
    {
        [JsonProperty("ticket_id")]
        public int? ticket_id { get; set; }
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
    }
    public class Ticket
    {
        [JsonProperty("ticket_number")]
        public string ticket_number { get; set; }
        [JsonProperty("code_identify")]
        public string code_identify { get; set; }
        [JsonProperty("created_at_for_sla")]
        public string created_at_for_sla { get; set; }
    }
    public class Detail
    {
        [JsonProperty("serial")]
        public string serial { get; set; }
    }
    public class item_master
    {
        [JsonProperty("description")]
        public string description { get; set; }
    }
}
