using Registration.Client.BlazorDto;

namespace Registration.Client.Services.Interfaces
{
    public interface IStudentBlazorService
    {
        Task<IEnumerable<StudentDto>> All();
    }
}
