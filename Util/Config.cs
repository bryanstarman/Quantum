﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Util
{
    public class Config
    {
        public string ApiUrl { get; set; } = "https://dc60-157-100-110-67.ngrok-free.app/api/";
        public HttpClient client { get; } = new HttpClient();

    }
    public class ErrorResponse
    {
        public string Message { get; set; }
    }

}
