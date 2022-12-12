using Registration.Client.BlazorDto;
using Registration.Client.Services.Interfaces;
using Registration.Shared.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Registration.Client.Services.Implemintations
{
    public class RegistrationBlazorService : IRegistrationBlazorService
    {
        private readonly HttpClient _httpClient;

        public RegistrationBlazorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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

        public async Task<bool> AddRegistration(int studentId, List<int> CoursePerLecturerIds)
        {

            var result = await _httpClient.PostAsJsonAsync($"Registration/AddRegistration?studentId={studentId}",
               CoursePerLecturerIds);
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid)
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<int>>
                (await _httpClient.GetStreamAsync($"Registration/GetDaySlotByCourseAndLecturer?courseid={courseid}&lecturerid={lecturerid}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<int>();
            }
        }

        public async Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId)
        {
            var result = await JsonSerializer.DeserializeAsync<int>
                (await _httpClient.GetStreamAsync($"Registration/GetLectrurerCourseID?coursid={courseId}&lectrurerid={lecturerId}&slotperdayId={slotPerDayId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if(result != null)
            {
                return result;
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid)
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Lecturer>>
                (await _httpClient.GetStreamAsync($"Registration/GetLecturerListOFCourse?courseId={courseid}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new List<Lecturer>();
            }
        }

        public async Task<IEnumerable<Course>> GetListOfAvailableCourses(int studentId)
        {
            var result = await JsonSerializer.DeserializeAsync<IEnumerable<Course>>
                (await _httpClient.GetStreamAsync($"Registration/GetListOfAvailableCourses?studentid={studentId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if(result != null)
            {
                return result;   
            }
            else
            {
                return new List<Course>();
            }
        }

        public async Task<StudentDto> GetStudentByUserID(string userId)
        {
            var result = await JsonSerializer.DeserializeAsync<StudentDto>
                (await _httpClient.GetStreamAsync($"Student/GetStudentByUserID?userId={userId}"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (result != null)
            {
                return result;
            }
            else
            {
                return new StudentDto();
            }
        }
    }
}
