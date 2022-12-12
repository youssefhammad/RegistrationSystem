using Registration.Client.BlazorDto;

namespace Registration.Client.Services.Interfaces
{
    public interface IStudentschedBlazorService
    {
        Task<IEnumerable<StudentSchduleView>> ViewSchedule
            (int studentid, DateTime startdate, DateTime enddate);

        Task<PermissionDto> GetLastPermissionTime();
    }
}
