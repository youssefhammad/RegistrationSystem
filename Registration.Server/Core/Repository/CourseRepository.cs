using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class CourseRepository : GenericRepository<Course> , ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context,
            ILogger logger) : base(context, logger)
        {
        }
        public override async Task<IEnumerable<Course>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(CourseRepository));
                return new List<Course>();
            }
        }

        public override async Task<bool> Upsert(Course entity)
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
                    existingStudent.Name = entity.Name;
                    existingStudent.DepartmentId = entity.DepartmentId;
                    existingStudent.Department = entity.Department;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert method error", typeof(CourseRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var existing = await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existing != null)
                {
                    _dbSet.Remove(existing);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(CourseRepository));
                return false;
            }
        }
    }
}
