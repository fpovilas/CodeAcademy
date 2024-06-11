using FinalProject.Business.Service.Interface;
using FinalProject.Main.Controllers;
using FinalProject.Shared.CustomExceptions;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;
using FinalProject.Test.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;

namespace FinalProject.Test
{
    public class UserControllerTests
    {
        [Theory, TestData(TestDataValue.UCSuccess)]
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

        [Theory, TestData(TestDataValue.UCFailure)]
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

        [Theory, TestData(TestDataValue.UCSuccess)]
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

        [Theory, TestData(TestDataValue.UCFailure)]
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

        [Theory, TestData(TestDataValue.UCSuccess)]
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

        [Theory, TestData(TestDataValue.UCFailure)]
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
            serviceMock.Setup(x => x.GetAll(It.IsAny<Claim>())).Throws(new Exception("User is not admin"));

            // Act
            var testResponse = sut.GetALL();

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse.Result);
        }

        [Theory, TestData(TestDataValue.UCSuccess)]
        public void UserController_AdminGetById_AdminGetsById_Success(Claim claim, UserAdminDTO user)
        {
            // Arrange
            var userClaim = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
           {
                claim
           }));
            var httpContext = new DefaultHttpContext
            {
                User = userClaim
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
            serviceMock.Setup(s => s.Get(It.IsAny<int>(), It.IsAny<Claim>())).Returns(user);

            // Act
            var testResponse = sut.GetById(It.IsAny<int>());
            var testResponseResult = Assert.IsType<OkObjectResult>(testResponse.Result);
            var value = Assert.IsType<UserAdminDTO>(testResponseResult.Value);

            // Assert
            Assert.Equal(user, value);
        }

        [Theory, TestData(TestDataValue.UCFailure)]
        public void UserController_AdminGetById_AdminGetsById_Failure(Claim claim)
        {
            // Arrange
            var userClaim = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                claim
            }));
            var httpContext = new DefaultHttpContext
            {
                User = userClaim
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
            serviceMock.Setup(x => x.GetAll(It.IsAny<Claim>())).Throws(new Exception("User is not admin"));

            // Act
            var testResponse = sut.GetALL();

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse.Result);
        }

        [Theory, TestData(TestDataValue.UCSuccess)]
        public void UserController_AdminDelete_AdminDeletes_Success(Claim claim, UserAdminDTO user)
        {
            // Arrange
            var userClaim = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
           {
                claim
           }));
            var httpContext = new DefaultHttpContext
            {
                User = userClaim
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
            serviceMock.Setup(s => s.Delete(It.IsAny<int>(), It.IsAny<IEnumerable<Claim>>())).Returns($"Successfully deleted {user.Username}");

            // Act
            var testResponse = sut.DeletePersonalInformation(It.IsAny<int>());

            // Assert
            Assert.IsType<OkObjectResult>(testResponse);
        }

        [Theory, TestData(TestDataValue.UCFailure)]
        public void UserController_AdminDelete_AdminDeletes_Failure(Claim claim)
        {
            // Arrange
            var userClaim = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                claim
            }));
            var httpContext = new DefaultHttpContext
            {
                User = userClaim
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
            serviceMock.Setup(x => x.Delete(It.IsAny<int>(), It.IsAny<IEnumerable<Claim>>())).Throws(new NoDataException("No data. Something went wrong."));

            // Act
            var testResponse = sut.DeletePersonalInformation(It.IsAny<int>());

            // Assert
            Assert.IsType<BadRequestObjectResult>(testResponse);
        }
    }
}