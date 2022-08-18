using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TFSUserRepository : GenericRepository<TFSUser>, ITFSUserRepository
    {
        private readonly ScrumDbContext _context;

        public TFSUserRepository(ScrumDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> ChangeStatus(int id, bool status)
        {
            var user = await GetById(id);
            user.IsActive = status;
            _context.TFSUsers.Update(user);
            return await _context.SaveChangesAsync();
        }
        public async Task<List<TFSUser>> GetByDepartmentId(int departmentId)
            => await _context.TFSUsers
                    .Where(x => x.DepartmentId == departmentId).ToListAsync();

        public async Task<List<TFSUser>> GetBySquadId(int squadId)
            => await _context.TFSUsers.Where(x => x.SquadId == squadId).OrderBy(x => x.Ordering).ToListAsync();

        /// <summary>
        ///     Name Field Can be Name, UserName or TFSName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public async Task<TFSUser> GetByNameType(string name)
        {
            var user = await _context.TFSUsers
                        .FirstOrDefaultAsync(x => (x.TFSName ?? x.UserName ?? x.Name).ToLower().Trim() == name.ToLower().Trim());

            return user;
        }

        public async Task<TFSUser> GetByTFSOrUserName(string name, string password)
        {
            var user = await _context.TFSUsers
                .FirstOrDefaultAsync(m => (m.TFSName.ToLower().Trim() == name.ToLower().Trim() || m.UserName.ToLower().Trim() == name.ToLower().Trim())
            && m.IsActive && m.Password == password);

            return user;
        }

        public async Task<TFSUser> GetByUsername(string userName)
            => await _context.TFSUsers.FirstOrDefaultAsync(x => (x.UserName).ToLower().Trim()
                                                            == userName.ToLower().Trim());

        public async Task<TFSUser> GetByTFSName(string tfsName)
            => await _context.TFSUsers.FirstOrDefaultAsync(x => (x.TFSName).ToLower().Trim()
                                                            == tfsName.ToLower().Trim());
    }
}
