
using Newtonsoft.Json;
using Quantum.Service;

public class UserService
{
    private static readonly HttpClient client = new HttpClient();
  
    
    public static async Task<UserResponse> LoginAsync(string email, string password)
    {
        var url = "https://7850-157-100-111-10.ngrok-free.app/api/login";
        var values = new Dictionary<string, string>
        {
            { "email", email },
            { "password", password }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await client.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Estas credenciales no coinciden con nuestros registros.");
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var userResponse = JsonConvert.DeserializeObject<UserResponse>(responseString);
        
        return userResponse;
    }
}
