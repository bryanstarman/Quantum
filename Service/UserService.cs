
using Newtonsoft.Json;
using Quantum.Util;


public class UserService
{
    private readonly Config _config =  new Config();

    public async Task<UserResponse> LoginAsync(string email, string password)
    {
        var url = _config.ApiUrl+"login";
        var values = new Dictionary<string, string>
        {
            { "email", email },
            { "password", password }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await _config.client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            var errorObj = JsonConvert.DeserializeObject<ErrorResponse>(errorResponse);
            throw new Exception(errorObj.Message);

        }

        var responseString = await response.Content.ReadAsStringAsync();
        var userResponse = JsonConvert.DeserializeObject<UserResponse>(responseString);
        
        return userResponse;
    }
}
