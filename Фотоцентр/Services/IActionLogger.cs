namespace Фотоцентр.Services
{
    public interface IActionLogger
    {
        Task LogActionAsync(int userId, string actionType, string details, string tableName, string severityLevel);
    }

}
