using Registration.Server.Core.IConfiguration;
using Registration.Server.Core.IRepository;
using Registration.Server.Core.Repository;

namespace Registration.Server.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext context, ILoggerFactory logger)
        {
            _context = context;
            _logger = logger.CreateLogger("logs");

            Students = new StudentRepository(_context,_logger);
            Courses = new CourseRepository(_context, _logger);
            Registrations = new RegistrationRepository(_context, _logger);
            CoursesPerLecturers = new CoursePerLecturerRepository(_context, _logger);
            Admins = new AdminRepository(_context,_logger);
            Permissions = new PermissionRepository(context,_logger);
        }

        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }
        public IRegistrationRepository Registrations { get; private set; }

        public ICoursePerLecturerRepository CoursesPerLecturers { get; private set; }

        public IAdminRepository Admins { get; private set; }

        public IPermissionRepository Permissions { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
