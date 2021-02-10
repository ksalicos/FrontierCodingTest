using CodingTest.Common.Models.ViewModels;
using CodingTest.Common.Services;
using CodingTest.Web.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodingTest.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private readonly Mock<ILogger<HomeController>> _loggerMock;
        private readonly Mock<IAccountService> _accountServiceMock;
        public HomeControllerTests()
        {
            _loggerMock = new Mock<ILogger<HomeController>>();
            _accountServiceMock = new Mock<IAccountService>();
        }

        [TestMethod]
        public void IndexRenders()
        {
            _accountServiceMock.Setup(s => s.GetAll()).Returns(new GetAllViewModel());
            var controller = new HomeController(_loggerMock.Object, _accountServiceMock.Object);
            controller.Index();
        }
    }
}
