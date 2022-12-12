using Registration.Server.Core.Repository;
using Registration.Server.DTOs;
using Registration.Shared.Models;
using System.Linq.Expressions;

namespace Registration.Server.Services.IService
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> All();
        Task<StudentDto> GetById(int id);
        Task<bool> Add(Student entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(Student entity);
        Task<IEnumerable<Student>> Find(Expression<Func<Student, bool>> predicate);
        Task<StudentDto> GetStudentByUserID(string userid);
    }
}
