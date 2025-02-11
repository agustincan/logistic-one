using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Transport.Api.Controllers;
using Transport.Api.Services;
using Transport.Domain.Models;
using Transport.Repository.Repos;

namespace Transport.Test.Unit
{
    [TestClass]
    public sealed class TransportControllerTests
    {
        Mock<IMediator> mockMediator;
        Mock<ITransportRepository> mockTransportRepo;
        Mock<ITransportService> mockTransportService;

        public TransportControllerTests()
        {
            Setup();
        }

        public void Setup()
        {
            mockTransportRepo = new Mock<ITransportRepository>();
            mockMediator = new Mock<IMediator>();
            mockTransportService = new Mock<ITransportService>();
        }

        [TestMethod]
        public async Task TransportController_GetByIds_IsOk()
        {
            var res = new List<Transportt>();
            res.Add(new Transportt() { Id = 1, License = "LIC111" });
            res.Add(new Transportt() { Id = 2, License = "LIC112" });
            var mockTransportContoller = new TransportController(mockTransportService.Object);
            mockTransportService.Setup(s => s.GetByIdsAsync(It.IsAny<int[]>())).ReturnsAsync(res);
            mockTransportRepo.Setup(s => s.GetByIdsAsync(It.IsAny<int[]>())).ReturnsAsync(res);
            var result = await mockTransportContoller.GetByIds(It.IsAny<int[]>());
            // Assert
            mockTransportService.Verify(v => v.GetByIdsAsync(It.IsAny<int[]>()), Times.Once);
            //mockTransportRepo.Verify(v => v.GetByIdsAsync(It.IsAny<int[]>()), Times.Once);
            
            Assert.IsInstanceOfType<OkObjectResult>(result);
        }
    }
}
