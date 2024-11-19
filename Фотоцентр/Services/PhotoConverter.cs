using Фотоцентр.Data;
using Фотоцентр.Models;

namespace Фотоцентр.Services
{
    public class PhotoConverter
    {
        
        public static string ConvertToBase64(Photo photo)
        {
            if (photo.Image == null || photo.Content_Type == null)
                return string.Empty;

            string base64String = Convert.ToBase64String(photo.Image);
            return $"data:{photo.Content_Type};base64,{base64String}";
        }

        public static async Task SavePhotoAsync(int orderId, byte[] imageBytes, string? contentType, string photoUrl)
        {
            using var context = new AppDbContext();
            ActionLogger ActionLogger = new ActionLogger(context);
            try
            {
                // Создаем новый объект фото для сохранения в базе данных
                var photo = new Photo
                {
                    Order_Id = orderId,
                    Image = imageBytes,           // Сохраняем изображение как байты
                    Content_Type = contentType,   // Сохраняем тип контента изображения (например, image/png)
                    Is_Final = false,             // Пока фото не финальное
                    Photo_Url = photoUrl          // Здесь можно оставить URL, если он все еще нужен
                };

                // Используем DbContext для взаимодействия с базой данных
                
                // Добавляем фото в базу данных
                context.Photos.Add(photo);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Логируем ошибку, если не удалось сохранить фото
                await ActionLogger.LogActionAsync(-1, // Можно использовать -1, если это не связано с конкретным пользователем
                    "Ошибка при сохранении фото",
                    $"Произошла ошибка при сохранении фото для заказа {orderId}: {ex.Message}",
                    "Photos",
                    "error");

                throw new Exception($"Ошибка при сохранении фото: {ex.Message}");
            }
        }

    }
}
