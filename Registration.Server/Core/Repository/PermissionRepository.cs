using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class PermissionRepository : GenericRepository<Permission>,
        IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context, ILogger logger) : 
            base(context, logger)
        {
        }

        public async Task<bool> AddNewTimePermisssion(PostPermissionDto entity)
        {
            Permission p = new Permission()
            {
                AdminId = entity.AdminId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };
            await _context.Permissions.AddAsync(p);
            return true;
        }

        public async Task<Permission> GetLastPermissionTime()
        {
            var permission = await _context.Permissions
                .Include(a => a.Admin).OrderBy(s=> s.Id)
                .LastOrDefaultAsync();
            return permission;
        }

        
    }
}
