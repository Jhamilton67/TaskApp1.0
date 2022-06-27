using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess.Interfaces
{
    public interface IDBUserData
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUsefromAuthentication(string objectid);
        Task<UserModel> GetUser(string id);
        Task<List<UserModel>> GetUserAsync();
        Task UpdateUser(UserModel user);
    }
}