// profile.js

document.addEventListener('DOMContentLoaded', function () {
    var toggleButton = document.getElementById('toggleDropdown');
    var dropdownMenu = document.getElementById('dropdownMenu');

    function toggleDropdown(event) {
        event.preventDefault(); // Предотвращаем переход по ссылке
        const isOpen = dropdownMenu.style.display === "block";
        dropdownMenu.style.display = isOpen ? "none" : "block"; // Переключаем видимость
        toggleButton.setAttribute('aria-expanded', !isOpen); // Обновляем aria атрибут
    }

    // Добавляем обработчик событий для кнопки и иконки
    toggleButton.addEventListener('click', toggleDropdown);

    // Закрыть выпадающее меню при клике вне его
    window.addEventListener('click', function (event) {
        // Проверяем, кликнули ли мы вне кнопки и выпадающего меню
        if (!toggleButton.contains(event.target) && !dropdownMenu.contains(event.target)) {
            dropdownMenu.style.display = "none"; // Скрываем меню
            toggleButton.setAttribute('aria-expanded', 'false'); // Обновляем aria атрибут
        }
    });

    // Закрытие меню по клавише Enter
    toggleButton.addEventListener('keydown', function (event) {
        if (event.key === 'Enter' || event.key === ' ') {
            event.preventDefault(); // Предотвращаем переход
            toggleDropdown(event); // Вызываем функцию переключения
        }
    });
});
