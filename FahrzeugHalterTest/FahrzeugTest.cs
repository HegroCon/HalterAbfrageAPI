using HalterAbfrageAPI;
using HalterAbfrageAPI.Controllers;
using HalterAbfrageAPI.Data;
using HalterAbfrageAPI.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace FahrzeugHalterTest
{
    public class FahrzeugTests
    {
        [Test]
        public async Task FahrzeugByKennzeichen_ShouldBeFoundAsync()
        {
            // Arrange
            IList<Stadt> staedte = new List<Stadt>
            {
                new Stadt
                {
                    Plz = "93152",
                    Name = "Nittendorf",
                    Bundesland = "Bayern"
                }
            };
            IList<Person> personen = new List<Person>
            {
                new Person
                {
                    Name = "Huber",
                    Vorname = "Hans",
                    Birthday = new DateTime(2002, 02, 12),
                    Id = 1,
                    StrasseHausnummer = "Teststraße 1",
                    StadtId = "93152"
                }
            };
            var expectedfahrzeug = new Fahrzeug
            {
                Kennzeichen = "R-AB1234",
                Marke = "VW",
                Kategory = "Pkw",
                Farbe = "rot",
                Person = personen.Where(p => p.Id == 1).FirstOrDefault()
            };

            IList<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
            fahrzeuge.Add(expectedfahrzeug);

            var serviceMock = new Mock<IHalterAbfrageService>();
            var contextMock = new Mock<MyDbContext>();
            var service = new FahrzeugController(contextMock.Object,serviceMock.Object);
            string kennzeichen = "R-AB1234";
            
            contextMock.Setup(m => m.Fahrzeuge).ReturnsDbSet(fahrzeuge);

            // Act
            //var actualFahrzeug = await service.GetFahrzeug(kennzeichen);
            var actualFahrzeug = await serviceMock.Object.GetFahrzeugByKennzeichen(kennzeichen);

            // Arrange
            serviceMock.Verify(
                s => s.GetFahrzeugByKennzeichen(kennzeichen), Times.Once);
            Assert.That(actualFahrzeug, Is.EqualTo(expectedfahrzeug));
        }
    }
}