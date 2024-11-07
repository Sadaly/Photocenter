using Microsoft.EntityFrameworkCore;
using Фотоцентр.Data;
using Фотоцентр.Models;
using Фотоцентр.Services;

namespace Фотоцентр.Components.Classes
{
    public class UserManager : IUser
    {
        readonly AppDBContext _dbContext = new();
        public UserManager(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Для получения всех данных о пользователе
        public List<User> GetUserDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }
        //Для добавления новой записи пользователя
        public void AddUser(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Для обновления записи конкретного пользователя
        public void UpdateUserDetails(User user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //Для получения информации о конкретном пользователе
        public User GetUserData(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        //Для удаления записи конкретного пользователя
        public void DeleteUser(int id)
        {
            try
            {
                User? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}