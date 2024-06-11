using AutoMapper;
using FinalProject.Business.Service;
using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.DTOs;
using FinalProject.Shared.Enums;
using FinalProject.Test.Data;
using Moq;

namespace FinalProject.Test
{
    public class UserServiceTests
    {
        [Theory, TestData(TestDataValue.USSuccess)]
        public void UserService_SignUp_SignsUp_Success(SignUpUserDTO user)
        {
            // Arrange
            var repoMock = new Mock<IUserRepository>();
            var jwtMock = new Mock<IJWTService>();
            var mapperMock = new Mock<IMapper>();
            var sut = new UserService(repoMock.Object, jwtMock.Object, mapperMock.Object);
            repoMock.Setup(s => s.SignUp(It.IsAny<User>())).Verifiable();

            // Act
            sut.SignUp(user);

            // Assert
            repoMock.Verify(r => r.SignUp(It.IsAny<User>()), Times.Once);
        }

        [Theory, TestData(TestDataValue.USSuccess)]
        public void UserService_LogIn_LogsIn_Success(User user, SignUpUserDTO userDTO)
        {
            // Arrange
            var shouldBeValue = "You have entered bad password";
            var repoMock = new Mock<IUserRepository>();
            var jwtMock = new Mock<IJWTService>();
            var mapperMock = new Mock<IMapper>();
            var sut = new UserService(repoMock.Object, jwtMock.Object, mapperMock.Object);
            repoMock.Setup(s => s.FindByUsername(It.IsAny<string>())).Returns(user);

            // Act
            var testResponse = sut.LogIn(userDTO);

            // Assert
            Assert.Equal(testResponse, shouldBeValue);
        }
    }
}
