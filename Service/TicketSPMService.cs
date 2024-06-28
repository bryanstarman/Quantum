using Newtonsoft.Json;
using Quantum.Modelo;
using Quantum.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Quantum.Service
{
    class TicketSPMService
    {
        private readonly Config _config = new Config();

        public async Task<TicketSPMResponse> GetTicketSPMAsync()
        {
            var url = _config.ApiUrl + "trouble-ticket/list-mobile?project_id=9";

            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token not found. Please log in again.");
            }

            _config.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

           

            var response = await _config.client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                throw new Exception(errorResponse.Message);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var TicketSPMResponse = JsonConvert.DeserializeObject<TicketSPMResponse>(responseContent);

            return TicketSPMResponse;
        }
    }
}

