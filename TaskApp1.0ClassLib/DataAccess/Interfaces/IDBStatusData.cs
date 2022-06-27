using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess.Interfaces
{
    public interface IDBStatusData
    {
        Task CreateStatus(StatusModel status);
        Task<List<StatusModel>> GetAllStatuses();
    }
}