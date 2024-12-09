using Microsoft.AspNetCore.Components;
using NUnit.Framework;
using Фотоцентр.Data;
using Фотоцентр.Models.ViewModels;
using Фотоцентр.Models;
using Фотоцентр.Services;
using Moq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Фотоцентр.Components.Pages.Account;
using Microsoft.AspNetCore.Http;

namespace TestProject
{
    [TestFixture]
    public class LoginPageTests
    {
        private Mock<AppDbContext> _mockDbContext;
        private Mock<NavigationManager> _mockNavigationManager;
        private Mock<IActionLogger> _mockActionLogger;
        private Mock<HttpContext> _mockHttpContext;
        private LoginViewModel _validModel;
        private LoginViewModel _invalidModel;
        private Login _loginPage;


        [SetUp]
        public void SetUp()
        {
            _mockDbContext = new Mock<AppDbContext>();
            _mockNavigationManager = new Mock<NavigationManager>();
            _mockActionLogger = new Mock<IActionLogger>();
            _mockHttpContext = new Mock<HttpContext>();

            _loginPage = new Login
            {
                HttpContext = _mockHttpContext.Object
            };

            _validModel = new LoginViewModel
            {
                Username = "validUser",
                Password = "validPassword"
            };

            _invalidModel = new LoginViewModel
            {
                Username = "invalidUser",
                Password = "invalidPassword"
            };
        }

        [Test]
        public async Task Authenticate_ShouldSetErrorMessage_WhenUserNotFound()
        {
            // Arrange
            _mockDbContext
                .Setup(db => db.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>(), default))
                .ReturnsAsync((User)null);


            _loginPage.Model = _invalidModel;

            // Act
            await _loginPage.Authenticate();

            // Assert
            Assert.That(_loginPage.errorMessage, Is.EqualTo("Неверное имя пользователя или пароль"));
        }

        [Test]
        public async Task Authenticate_ShouldRedirectToHome_WhenCredentialsAreValid()
        {
            // Arrange
            var user = new User
            {
                Username = "validUser",
                Password_Hash = PasswordHelper.HashPassword("validPassword"),
                User_Id = 1,
                Role = "client"
            };

            _mockDbContext
               .Setup(db => db.Users.FirstOrDefaultAsync(It.IsAny<Expression<Func<User, bool>>>(), default))
               .ReturnsAsync((User)null);

            _loginPage.Model = _validModel;

            // Act
            await _loginPage.Authenticate();

            // Assert
            Assert.That(string.IsNullOrEmpty(_loginPage.errorMessage), Is.True);

            _mockNavigationManager.Verify(nm => nm.NavigateTo("/", true), Times.Once);
        }
    }
}
