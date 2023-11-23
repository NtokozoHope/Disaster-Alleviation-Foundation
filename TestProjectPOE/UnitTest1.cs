using Disaster_Alleviation_Foundation.Controllers;
using Disaster_Alleviation_Foundation.Data;
using Disaster_Alleviation_Foundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestProjectPOE
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AllocateGoods_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var DAFContextMock = new Mock<DAFContext>();

            HomeController controller = new HomeController(loggerMock.Object, DAFContextMock.Object);
            var goodsAllocationModelMock = new Mock<GoodsAllocation>();

            // Act
            IActionResult result = controller.AllocateGoods(goodsAllocationModelMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void InfoViews_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var DAFContextMock = new Mock<DAFContext>();

            HomeController controller = new HomeController(loggerMock.Object, DAFContextMock.Object);
            

            // Act
            Task result = controller.InfoView();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CapturePurchase_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var DAFContextMock = new Mock<DAFContext>();

            HomeController controller = new HomeController(loggerMock.Object, DAFContextMock.Object);
            var CapturePurchaseionModelMock = new Mock<capturePurchase>();

            // Act
            IActionResult result = controller.CapturePurchase(CapturePurchaseionModelMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Disaster_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var DAFContextMock = new Mock<DAFContext>();

            HomeController controller = new HomeController(loggerMock.Object, DAFContextMock.Object);
            var DisasterModelMock = new Mock<Disaster>();

            // Act
            IActionResult result = controller.Disaster(DisasterModelMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Register_Returns_ViewResult()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<HomeController>>();
            var DAFContextMock = new Mock<DAFContext>();

            HomeController controller = new HomeController(loggerMock.Object, DAFContextMock.Object);
            var RegisterModelMock = new Mock<Users>();

            // Act
            IActionResult result = controller.Register(RegisterModelMock.Object);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}