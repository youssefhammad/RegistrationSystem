using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class AdminRepository : GenericRepository<Admin>,
        IAdminRepository
    {
        public AdminRepository(ApplicationDbContext context, ILogger logger) :
            base(context, logger)
        {
        }

        public async Task<Admin> GetAdminByUserId(string userId)
        {
            var admin = await _dbSet.Where(a => a.UserId == userId).FirstOrDefaultAsync();
            return admin;
        }
    }
}
