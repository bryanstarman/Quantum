
using Newtonsoft.Json;
using Quantum.Modelo;
using Quantum.Util;
using System.Net.Http.Headers;

namespace Quantum.Service
{
    public class ProyectUserService
    {
        private readonly Config _config = new Config();

        public async Task<ProjectResponse> GetUserProjectsAsync()
        {
            var url = _config.ApiUrl + "user/projects";

            var token = await SecureStorage.GetAsync("auth_token");

            if (string.IsNullOrEmpty(token))
            {
                throw new Exception("Token not found. Please log in again.");
            }

            _config.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{token}");

            var content = new StringContent("");

            var response = await _config.client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(responseString);
                throw new Exception(errorResponse.Message);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var projectResponse = JsonConvert.DeserializeObject<ProjectResponse>(responseContent);

            return projectResponse;
        }
    }
}
