using API.Controllers;
using API.Service.Interface;
using AutoFixture;
using AutoFixture.Xunit2;
using DatabaseLayer.Database.Model;
using Microsoft.Extensions.Logging;
using Moq;
using xUnitAPITest.Attribute;
using xUnitAPITest.SpecimenBuilder;

namespace xUnitAPITest
{
    public class TestAPI
    {
        private readonly Fixture _fixture = new();

        public TestAPI()
        {
            _fixture.Customizations.Add(new CarSpecimenBuilder());
        }

        [Theory, CustomData]
        public void CustomAttribute_ServiceTest_GetCarByID_GetsCarByID_Correctly(Car car)
        {
            //Arrange
            var serviceMock = new Mock<ICarService>();
            var loggerMock = new Mock<ILogger<CarController>>();
            var sut = new CarController(loggerMock.Object, serviceMock.Object); //SUT - Subject Under Test
            serviceMock.Setup(x => x.GetCarByID(It.IsAny<int>())).Returns(car);

            //Act
            var testRespone = sut.GetCarByID(It.IsAny<int>());

            //Assert
            Assert.Equal(testRespone, car);

        }

        // () => Console.WriteLine()

        [Theory, AutoData]
        public void Fixture_ServiceTest_GetCarByID_GetsCarByID_Correctly()
        {
            //Fixture
            var fixturedCar = _fixture.Create<Car>();

            //Arrange
            var serviceMock = new Mock<ICarService>();
            var loggerMock = new Mock<ILogger<CarController>>();
            var sut = new CarController(loggerMock.Object, serviceMock.Object); //SUT - Subject Under Test
            serviceMock.Setup(x => x.GetCarByID(It.IsAny<int>())).Returns(fixturedCar);

            //Act
            var testRespone = sut.GetCarByID(It.IsAny<int>());

            //Assert
            Assert.Equal(testRespone, fixturedCar);

        }

        [Theory, AutoData]
        public void ServiceTest_GetCarByID_GetsCarByID_Correctly(Car car)
        {
            //Arrange
            var serviceMock = new Mock<ICarService>();
            var loggerMock = new Mock<ILogger<CarController>>();
            var sut = new CarController(loggerMock.Object, serviceMock.Object); //SUT - Subject Under Test
            serviceMock.Setup(x => x.GetCarByID(It.IsAny<int>())).Returns(car);

            //Act
            var testRespone = sut.GetCarByID(It.IsAny<int>());

            //Assert
            Assert.Equal(testRespone, car);

        }
    }
}