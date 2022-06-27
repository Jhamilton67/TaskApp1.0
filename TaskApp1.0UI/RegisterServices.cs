using System.Data;
using System.Data.Common;
using TaskApp1._0ClassLib.DataAccess;
using TaskApp1._0ClassLib.DataAccess.Interfaces;
using DbConnection = TaskApp1._0ClassLib.DataAccess.DbConnection;
using IDbConnection = TaskApp1._0ClassLib.DataAccess.Interfaces.IDbConnection;

namespace TaskApp1._0UI8
{
    public static class RegisterServices
    {
        public static void ConfigureService(this WebApplicationBuilder web)
        {
            // Add services to the container.
            web.Services.AddRazorPages();
            web.Services.AddServerSideBlazor();
            web.Services.AddMemoryCache();

            web.Services.AddSingleton<IDbConnection, DbConnection>();
            web.Services.AddSingleton<IDBCatogeoryData, DBCatogeoryData>();
            web.Services.AddSingleton<IDBStatusData, DBStatusData>();
            web.Services.AddSingleton<IDbSuggestionData, DbSuggestionData>();
            web.Services.AddSingleton<IDBUserData, DBUserData>();
         
        }

    }

}
