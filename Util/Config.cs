using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Util
{
    public class Config
    {
        public string ApiUrl { get; set; } = "https://735c-157-100-111-10.ngrok-free.app/api/";
        public HttpClient client { get; } = new HttpClient();

    }
    public class ErrorResponse
    {
        public string Message { get; set; }
    }

}
