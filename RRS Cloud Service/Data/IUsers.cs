using RRS_Cloud_Service.Models;

namespace RRS_Cloud_Service.Data
{
    public interface IUsers
    {
        Task<IEnumerable<UserData>> GetAllUsers();
    }
}