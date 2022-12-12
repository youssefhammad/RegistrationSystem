using Registration.Shared.Models;

namespace Registration.Server.Core.IRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentByUserID(string userid);
    }
}
