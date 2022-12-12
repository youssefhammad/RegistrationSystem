using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using System.Text.Json;

namespace Registration.Client.Services.Implemintations
{
    public class StudentBlazorService : IStudentBlazorService
    {
        private readonly HttpClient _httpClient;

        public StudentBlazorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentDto>> All()
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<StudentDto>>
                (await _httpClient.GetStreamAsync($"Student"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<StudentDto>();
            }
        }


    }
}
