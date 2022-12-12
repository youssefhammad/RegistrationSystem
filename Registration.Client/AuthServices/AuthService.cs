using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Registration.Shared.AuthModels;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Registration.Client.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly JsonSerializerOptions _options;

        public AuthService(HttpClient httpClient,
                           ILocalStorageService localStorage)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClient;
            _localStorage = localStorage;
        }

        public async Task<RegisterResult> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/accounts", registerModel);
            return await result.Content.ReadFromJsonAsync<RegisterResult>();

        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var content = JsonSerializer.Serialize(loginModel);
            var bodyContent = new StringContent(content.ToString(), Encoding.UTF8, "application/json");

            var authResult = await _httpClient.PostAsync("api/Login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<LoginResult>(authContent, _options);

            if (!authResult.IsSuccessStatusCode)
                return result;

            await _localStorage.SetItemAsync("authToken", result.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).NotifyUserAuthentication(result.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

            return new LoginResult { IsAuthSuccessful = true };
           


        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
