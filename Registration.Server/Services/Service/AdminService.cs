using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;
using Registration.Shared.Models;

namespace Registration.Server.Services.Service
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }
        public async Task<Admin> GetAdminByUserId(string userId)
        {
            var admin = await _unitOfWork.Admins.GetAdminByUserId(userId);
            if(admin != null)
            {
                return admin;
            }
            else
            {
                return new Admin();
            }
        }
    }
}
