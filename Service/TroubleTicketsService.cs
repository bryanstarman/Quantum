using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantum.Modelo;
using Quantum.Util;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Quantum.Service
{
    public class TroubleTicketsService
    {
        private readonly Config _config = new Config();

       public async Task<TroubleTicketsResponse> GetTicketSPMAsync(int project_id)
        {
            var url = _config.ApiUrl + "trouble-ticket/list-mobile?project_id="+ project_id;

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
            var troubleTicketsResponse = JsonConvert.DeserializeObject<TroubleTicketsResponse>(responseContent);

            return troubleTicketsResponse;
        }
    }
}
