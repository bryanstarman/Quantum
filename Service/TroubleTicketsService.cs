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

        public async Task<TroubleTicketsResponse> GetTicketSPMAsync(int project_id,int? page,string? column_search,string? contain_search)
        {
            var url = _config.ApiUrl + "trouble-ticket/list-mobile?project_id=" + project_id;
            ;
            if (page is not null and > 0)
            {
                url += "&page=" + page;
            }
            if(column_search is not null && contain_search is not null)
            {
                url += $"&column_search={column_search}&contain_search={contain_search}";
            }

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

        public async Task<NewTicketSP> GetNewTicketSPAsync(int project_id)
        {
            var url = _config.ApiUrl + "number/" + project_id;

            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token not found. Please log in again.");
            }

            _config.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

            var content = new StringContent("");

            var response = await _config.client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                throw new Exception(errorResponse.Message);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var NewTicketSPResponse = JsonConvert.DeserializeObject<NewTicketSP>(responseContent);

            return NewTicketSPResponse;
        }


        public async Task<List<FailureCityResponse>> GetFailureCityResponseAsync(int? idBrash )
        {
            var url = _config.ApiUrl + "city-source" + "?type=failure_source&filter={%22branch_id%22:" + idBrash + "}&operation=store";

            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token not found. Please log in again.");
            }

            _config.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

            var content = new StringContent("");

            var response = await _config.client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                throw new Exception(errorResponse.Message);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var failureCityResponse = JsonConvert.DeserializeObject<List<FailureCityResponse>>(responseContent);

            return failureCityResponse;

        }


        public async Task<List<FailureCityResponse>> GetDeliveryResponseAsync(int? idBrash)
        {
            var url = _config.ApiUrl + "city-source" + "?type=delivery_source&filter={%22branch_id%22:" + idBrash + "}&operation=store";

            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token not found. Please log in again.");
            }

            _config.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

            var content = new StringContent("");

            var response = await _config.client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                throw new Exception(errorResponse.Message);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var failureCityResponse = JsonConvert.DeserializeObject<List<FailureCityResponse>>(responseContent);

            return failureCityResponse;

        }
    }


}
