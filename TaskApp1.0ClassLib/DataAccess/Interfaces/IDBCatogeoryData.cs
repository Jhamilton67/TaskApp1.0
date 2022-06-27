using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess.Interfaces
{
    public interface IDBCatogeoryData
    {
        Task CreateCategory(CatogeoryModel catogeory);
        Task<List<CatogeoryModel>> GetAllCatogeory();
    }
}