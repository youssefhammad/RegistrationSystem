using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context,
            ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Student>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(StudentRepository));
                return new List<Student>();
            }
        }

        public override async Task<bool> Upsert(Student entity)
        {
            try
            {
                var existingStudent = await _dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingStudent == null)
                {
                    return await Add(entity);
                }
                else
                {
                    existingStudent.FullName = entity.FullName;
                    existingStudent.FinishedHours = entity.FinishedHours;
                    existingStudent.DepartmentId = entity.DepartmentId;
                    existingStudent.Department = entity.Department;
                    existingStudent.GPA = entity.GPA;

                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(StudentRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var existing = await _dbSet.Where(x=> x.Id == id).FirstOrDefaultAsync();
                if(existing != null)
                {
                    _dbSet.Remove(existing);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(StudentRepository));
                return false;
            }
        }

        public async Task<Student> GetStudentByUserID(string userid)
        {
            var student = await _dbSet.Where(a => a.UserId == userid).FirstOrDefaultAsync();
            return student;
        }
    }
}
