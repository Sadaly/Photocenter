using Microsoft.EntityFrameworkCore;
using Фотоцентр.Data;
using Фотоцентр.Models;


namespace Фотоцентр.Services
{
    public class ActionLogger : IActionLogger
    {
        private readonly AppDbContext _context;

        public ActionLogger(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogActionAsync(int userId, string actionType, string details, string tableName, string severityLevel)
        {
            using (var context = new AppDbContext())
            {
                var actionLog = new ActionLog
                {
                    User_Id = userId,
                    Action_Type = actionType,
                    Action_Timestamp = DateTime.Now,
                    Details = details,
                    Table_Name = tableName,
                    Severity_Level = severityLevel
                };

                await _context.ActionLogs.AddAsync(actionLog);
                await _context.SaveChangesAsync();
            }
        }
    }

}
