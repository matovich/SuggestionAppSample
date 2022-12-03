namespace SuggestionAppLibrary.DataAccess
{
    public interface IStatusData
    {
        Task CreatStatusAsync(StatusModel status);
        Task<List<StatusModel>> GetAllStatusesAsync();
    }
}