using Registration.Server.DTOs;
using Registration.Shared.Models;
using System.Linq.Expressions;

namespace Registration.Server.Services.IService
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> All();
        Task<CourseDto> GetById(int id);
        Task<bool> Add(Course entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(Course entity);
        Task<IEnumerable<Student>> Find(Expression<Func<Course, bool>> predicate);
    }
}
