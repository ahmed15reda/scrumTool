using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITFSUserRepository
    {
        Task<TFSUser> GetByTFSOrUserName(string name, string password);
        Task<TFSUser> GetByUsername(string userName);
        Task<TFSUser> GetByNameType(string tfsName);
        Task<int> ChangeStatus(int id, bool status);
        Task<List<TFSUser>> GetByDepartmentId(int departmentId);
        //Task<TFSUser> GetByIdwithPassword(int id);
        Task<TFSUser> GetByTFSName(string tfsName);
        Task<List<TFSUser>> GetBySquadId(int squadId);
    }
}
