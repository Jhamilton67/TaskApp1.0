using TaskApp1._0ClassLib.Models;

namespace TaskApp1._0ClassLib.DataAccess.Interfaces
{
    public interface IDbSuggestionData
    {
        Task CreateSuggestion(SuggestionModel suggestion);
        Task<List<SuggestionModel>> GetAllApprovedSuggestions();
        Task<List<SuggestionModel>> GetAllSuggestions();
        Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval();
        Task<SuggestionModel> GetSuggestion(string id);
        Task UpdateSuggestion(SuggestionModel suggestion);
        Task UpvoteSuggestion(string SuggestionId, string userId);
    }
}