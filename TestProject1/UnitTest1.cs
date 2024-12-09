//using Bunit;
//using Microsoft.Extensions.DependencyInjection;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using Microsoft.AspNetCore.Components;
//using ���������.Data;
//using ���������.Models;
//using ���������.Services;
//using ���������.Components.Pages.Account;
//using Assert = Xunit.Assert;

//public class LoginTests : Bunit.TestContext
//{
//    private readonly AppDbContext _dbContext;
//    private readonly Mock<IActionLogger> _mockLogger;

//    public LoginTests()
//    {
//        // �������� ���� ������ � ������
//        var options = new DbContextOptionsBuilder<AppDbContext>()
//            .UseInMemoryDatabase("TestDb")
//            .Options;
//        _dbContext = new AppDbContext(options);

//        // ���������� ������������ � ���� ������ ��� ������
//        _dbContext.Users.Add(new User
//        {
//            Username = "testuser",
//            Password_Hash = PasswordHelper.HashPassword("testpassword"),
//            Role = "Admin",
//            User_Id = 1
//        });
//        _dbContext.SaveChanges();

//        // ������������� ���-������� ��� ActionLogger
//        _mockLogger = new Mock<IActionLogger>();
//    }

//    [Fact]
//    public async Task LoginPage_Should_Successfully_Authenticate_With_Valid_Credentials()
//    {
//        // ������� ���������
//        var component = RenderComponent<Login>();

//        // ������� �������� �����
//        var usernameInput = component.Find("input[placeholder='�����']");
//        var passwordInput = component.Find("input[placeholder='������']");
//        var submitButton = component.Find("button[type='submit']");

//        // ��������� �����
//        usernameInput.Change("testuser");
//        passwordInput.Change("testpassword");

//        // �������� �� ������ ��������
//        submitButton.Click();

//        // ���������, ��� ��������������� �� ������� �������� ���������
//        var navigationManager = component.Services.GetRequiredService<NavigationManager>();
//        Assert.Equal("/", navigationManager.Uri);
//    }

//    [Fact]
//    public async Task LoginPage_Should_Fail_Authentication_With_Invalid_Credentials()
//    {
//        // ������� ���������
//        var component = RenderComponent<Login>();

//        // ������� �������� �����
//        var usernameInput = component.Find("input[placeholder='�����']");
//        var passwordInput = component.Find("input[placeholder='������']");
//        var submitButton = component.Find("button[type='submit']");

//        // ��������� ����� � ������������� �������
//        usernameInput.Change("wronguser");
//        passwordInput.Change("wrongpassword");

//        // �������� �� ������ ��������
//        submitButton.Click();

//        // ���������, ��� ��������� ��������� �� ������
//        component.Markup.Contains("�������� ��� ������������ ��� ������");
//    }

//    [Fact]
//    public async Task LoginPage_Should_Trigger_ActionLogger_On_Successful_Login()
//    {
//        // ������� ���������
//        var component = RenderComponent<Login>();

//        // ������� �������� �����
//        var usernameInput = component.Find("input[placeholder='�����']");
//        var passwordInput = component.Find("input[placeholder='������']");
//        var submitButton = component.Find("button[type='submit']");

//        // ��������� ����� � ����������� �������
//        usernameInput.Change("testuser");
//        passwordInput.Change("testpassword");

//        // �������� �� ������ ��������
//        submitButton.Click();

//        // ���������, ��� ����� ����������� ��� ������
//        _mockLogger.Verify(logger => logger.LogActionAsync(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
//    }
//}
