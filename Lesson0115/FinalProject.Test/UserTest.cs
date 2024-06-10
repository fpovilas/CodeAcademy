using AutoFixture;
using FinalProject.Business.Service.Interface;
using FinalProject.Main.Controllers;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using FinalProject.Test.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace FinalProject.Test
{
    public class UserTest
    {
        private readonly Fixture _fixture = new();

        public UserTest()
        {
            _fixture.Customizations.Add(new UserSpecimenBuilder());
        }

        [Theory, UserData]
        public void UserController_SignUp_SignUps_Success(SignUpUserDTO user)
        {
            // Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(x => x.SignUp(It.IsAny<SignUpUserDTO>()));

            // Act
            var testResponse = sut.SignUp(user);

            // Assert
            Assert.IsType<OkObjectResult>(testResponse.Result);
        }

        [Theory, UserData("Failure")]
        public void UserController_SignUp_SignUps_Failure(SignUpUserDTO user)
        {
            // Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(x => x.SignUp(It.IsAny<SignUpUserDTO>()));

            // Act
            var testResponse = sut.SignUp(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse.Result);
        }

        [Theory, UserData]
        public void UserController_LogIn_LogsIn_Success(SignUpUserDTO user, string token)
        {
            // Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(x => x.LogIn(It.IsAny<SignUpUserDTO>())).Returns(token);

            // Act
            var testResponse = sut.LogIn(user);
            var okResult = Assert.IsType<OkObjectResult>(testResponse);
            var returnedToken = Assert.IsType<string>(okResult.Value);

            // Assert
            Assert.Equal(returnedToken, token);
        }

        [Theory, UserData("Failure")]
        public void UserController_LogIn_LogsIn_Failure(SignUpUserDTO user)
        {
            // Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(x => x.LogIn(It.IsAny<SignUpUserDTO>())).Throws(new BadPasswordException("You have entered bad password"));

            // Act
            var testResponse = sut.LogIn(user);

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse);
        }

        [Theory, UserData]
        public void UserController_AdminGetAll_AdminGetsAll_Success(Claim claim)
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                claim
            }));
            var httpContext = new DefaultHttpContext
            {
                User = user
            };
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object)
            {
                ControllerContext = controllerContext
            };
            serviceMock.Setup(x => x.GetAll(claim)).Returns([]);

            // Act
            var testResponse = sut.GetALL();

            // Assert
            Assert.NotNull(testResponse);
        }

        [Theory, UserData("Failure")]
        public void UserController_AdminGetAll_AdminGetsAll_Failure(Claim claim)
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                claim
            }));
            var httpContext = new DefaultHttpContext
            {
                User = user
            };
            var controllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object)
            {
                ControllerContext = controllerContext
            };
            serviceMock.Setup(x => x.GetAll(claim)).Throws(new Exception("User is not admin"));

            // Act
            var testResponse = sut.GetALL();

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse);
        }
    }
}