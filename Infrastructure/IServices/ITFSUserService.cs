using Core.Dto;
using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface ITFSUserService
    {
        public Task<int> AddUser(TFSUser tfsUser);
        public Task<int> ChangeStatus(int id, bool status);
        public Task<int> DeleteUser(int id);
        public Task<int> UpdateUser(TFSUser user);
        public Task<List<TFSUserDto>> GetAll();
        public Task<TFSUserDto> GetTFSUserById(int id);
    }
}
