using Registration.Server.Core.IConfiguration;
using Registration.Server.Core.IRepository;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;
using Registration.Shared.Models;
using System.Linq.Expressions;

namespace Registration.Server.Services.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public Task<bool> Add(Student entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDto>> All()
        {
            IEnumerable<Student> students = await _unitOfWork.Students.All();
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (Student student in students)
            {
                studentDtos.Add(new StudentDto
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    FinishedHours = student.FinishedHours,
                    GPA = student.GPA,
                    DepartmentId = student.DepartmentId,
                    Departmentt = student.Department


                });
            }
            return studentDtos;
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.Students.Delete(id);
        }

        public async Task<IEnumerable<Student>> Find(Expression<Func<Student, bool>> predicate)
        {
            return await _unitOfWork.Students.Find(predicate);
        }

        public async Task<StudentDto> GetById(int id)
        {
            var student = await _unitOfWork.Students.GetById(id);
            if (student != null)
            {
                StudentDto studentDto = new StudentDto()
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    FinishedHours = student.FinishedHours,
                    GPA = student.GPA,
                    DepartmentId = student.DepartmentId
                };

                return studentDto;
            }
            else
            {
                return new StudentDto();
            }
        }

        public async Task<StudentDto> GetStudentByUserID(string userid)
        {
            var student = await _unitOfWork.Students.GetStudentByUserID(userid);
            if (student != null)
            {
                StudentDto studentDto = new StudentDto()
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    FinishedHours = student.FinishedHours,
                    GPA = student.GPA,
                    DepartmentId = student.DepartmentId
                };
                return studentDto;
            }
            else
            {
                return new StudentDto();
            }
        }

        public Task<bool> Upsert(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
