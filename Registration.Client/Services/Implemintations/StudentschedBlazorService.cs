using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using System.Text.Json;

namespace Registration.Client.Services.Implemintations
{
    public class StudentschedBlazorService : IStudentschedBlazorService
    {
        private readonly HttpClient _httpClient;

        public StudentschedBlazorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<StudentSchduleView>> ViewSchedule(int studentid, DateTime startdate,
            DateTime enddate)
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<StudentSchduleView>>
                (await _httpClient.GetStreamAsync($"Registration/ViewSchedule?studentid={studentid}&startdate={startdate}&enddate={enddate}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<StudentSchduleView>();
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
