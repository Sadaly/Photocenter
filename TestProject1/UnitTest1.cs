//using Bunit;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Microsoft.AspNetCore.Components;
//using Фотоцентр.Data;
//using Фотоцентр.Models;
//using Фотоцентр.Services;
//using Фотоцентр.Components.Pages.Account;
//using Assert = Xunit.Assert;

//public class LoginTests : Bunit.TestContext
//{
//    private readonly AppDbContext _dbContext;
//    private readonly Mock<IActionLogger> _mockLogger;

//    public LoginTests()
//    {
//        // Создание базы данных в памяти
//        var options = new DbContextOptionsBuilder<AppDbContext>()
//            .UseInMemoryDatabase("TestDb")
//            .Options;
//        _dbContext = new AppDbContext(options);

//        // Добавление пользователя в базу данных для тестов
//        _dbContext.Users.Add(new User
//        {
//            Username = "testuser",
//            Password_Hash = PasswordHelper.HashPassword("testpassword"),
//            Role = "Admin",
//            User_Id = 1
//        });
//        _dbContext.SaveChanges();

//        // Инициализация мок-объекта для ActionLogger
//        _mockLogger = new Mock<IActionLogger>();
//    }

//    [Fact]
//    public async Task LoginPage_Should_Successfully_Authenticate_With_Valid_Credentials()
//    {
//        // Создаем компонент
//        var component = RenderComponent<Login>();

//        // Находим элементы формы
//        var usernameInput = component.Find("input[placeholder='Логин']");
//        var passwordInput = component.Find("input[placeholder='Пароль']");
//        var submitButton = component.Find("button[type='submit']");

//        // Заполняем форму
//        usernameInput.Change("testuser");
//        passwordInput.Change("testpassword");

//        // Нажимаем на кнопку отправки
//        submitButton.Click();

//        // Проверяем, что перенаправление на главную страницу произошло
//        var navigationManager = component.Services.GetRequiredService<NavigationManager>();
//        Assert.Equal("/", navigationManager.Uri);
//    }

//    [Fact]
//    public async Task LoginPage_Should_Fail_Authentication_With_Invalid_Credentials()
//    {
//        // Создаем компонент
//        var component = RenderComponent<Login>();

//        // Находим элементы формы
//        var usernameInput = component.Find("input[placeholder='Логин']");
//        var passwordInput = component.Find("input[placeholder='Пароль']");
//        var submitButton = component.Find("button[type='submit']");

//        // Заполняем форму с неправильными данными
//        usernameInput.Change("wronguser");
//        passwordInput.Change("wrongpassword");

//        // Нажимаем на кнопку отправки
//        submitButton.Click();

//        // Проверяем, что появилось сообщение об ошибке
//        component.Markup.Contains("Неверное имя пользователя или пароль");
//    }

//    [Fact]
//    public async Task LoginPage_Should_Trigger_ActionLogger_On_Successful_Login()
//    {
//        // Создаем компонент
//        var component = RenderComponent<Login>();

//        // Находим элементы формы
//        var usernameInput = component.Find("input[placeholder='Логин']");
//        var passwordInput = component.Find("input[placeholder='Пароль']");
//        var submitButton = component.Find("button[type='submit']");

//        // Заполняем форму с правильными данными
//        usernameInput.Change("testuser");
//        passwordInput.Change("testpassword");

//        // Нажимаем на кнопку отправки
//        submitButton.Click();

//        // Проверяем, что метод логирования был вызван
//        _mockLogger.Verify(logger => logger.LogActionAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
//    }
//}
