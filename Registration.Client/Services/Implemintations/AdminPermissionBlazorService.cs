using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using Registration.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Registration.Client.Services.Implemintations
{
    public class AdminPermissionBlazorService : IAdminPermissionBlazorService
    {
        private readonly HttpClient _httpClient;
        public AdminPermissionBlazorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddNewTimePermisssion(PostPermissionDto entity)
        {
            var result = await _httpClient.PostAsJsonAsync("Permission/AddNewTimePermisssion",
                entity);
            if(result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public async Task<Admin> GetAdminByUserId(string userId)
        {
            var result = await JsonSerializer.DeserializeAsync<Admin>
                (await _httpClient.GetStreamAsync($"Admin/GetAdminByUserId?userId={userId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new Admin();
            }
        }

        public async Task<PermissionDto> GetLastPermissionTime()
        {
            var result = await JsonSerializer.DeserializeAsync<PermissionDto>
                (await _httpClient.GetStreamAsync($"Permission/GetLastPermissionTime"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new PermissionDto();
            }
        }
    }
}
