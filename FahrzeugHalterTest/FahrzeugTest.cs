using HalterAbfrageAPI;
using HalterAbfrageAPI.Controllers;
using HalterAbfrageAPI.Data;
using Moq;

namespace FahrzeugHalterTest
{
    public class FahrzeugTests
    {
        [Test]
        public void FahrzeugByKennzeichen_ShouldBeFound()
        {
            // Arrange
            var serviceMock = new Mock<IHalterAbfrageService>();
            var contextMock = new Mock<MyDbContext>();
            var service = new FahrzeugController(contextMock.Object,serviceMock.Object);
            string kennzeichen = "R-AB1234";

            // Act
            service.GetFahrzeug(kennzeichen);

            // Arrange
            serviceMock.Verify(
                s => s.GetFahrzeugByKennzeichen(kennzeichen), Times.Once);
        }
    }
}