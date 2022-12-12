using Registration.Server.Core.IRepository;

namespace Registration.Server.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IStudentRepository Students { get; }
        ICourseRepository Courses { get; } 
        IRegistrationRepository Registrations { get; }
        ICoursePerLecturerRepository CoursesPerLecturers { get; }
        IAdminRepository Admins { get; }
        IPermissionRepository Permissions { get; }

        Task CompleteAsync();
    }
}
