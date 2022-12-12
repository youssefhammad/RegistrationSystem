using Registration.Server.Core.IConfiguration;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;
using Registration.Shared.Models;
using System.Linq.Expressions;

namespace Registration.Server.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Add(Course entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourseDto>> All()
        {
            IEnumerable<Course> courses = await _unitOfWork.Courses.All();
            List<CourseDto> coursesDto = new List<CourseDto>();
            foreach(Course course in courses)
            {
                coursesDto.Add(new CourseDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    CreditHours = course.CreditHours,
                    DependentOnCourseID = course.DependentOnCourseID,
                    DepartmentId = course.DepartmentId
                });
            }
            return coursesDto;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> Find(Expression<Func<Course, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<CourseDto> GetById(int id)
        {
            var course = await _unitOfWork.Courses.GetById(id);
            if(course == null)
            {
                return new CourseDto();
            }
            else
            {
                CourseDto courseDto = new CourseDto()
                {
                    Id = course.Id,
                    Name = course.Name,
                    CreditHours = course.CreditHours,
                    DependentOnCourseID = course.DependentOnCourseID,
                    DepartmentId = course.DepartmentId
                };

                return courseDto;
            }
        }

        public Task<bool> Upsert(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
