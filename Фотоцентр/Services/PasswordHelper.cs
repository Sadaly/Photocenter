using System.Security.Cryptography;
using System.Text;

namespace Фотоцентр.Services
{
    public class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Получаем байты пароля
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Преобразуем байты в строку
                StringBuilder builder = new StringBuilder();
                foreach (var byteData in bytes)
                {
                    builder.Append(byteData.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
