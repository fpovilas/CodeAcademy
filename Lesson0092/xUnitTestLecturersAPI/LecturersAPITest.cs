using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestPracticeApplication.Controllers;
using UnitTestPracticeApplication.DTOs;
using UnitTestPracticeApplication.Models;
using UnitTestPracticeApplication.Services;
using xUnitTestLecturersAPI.Attribute;

namespace xUnitTestLecturersAPI
{
    public class LecturersAPITest
    {
        #region BookService Success Tests

        [Theory, CustomResponseDto]
        public void Service_AddBook_AddsBook_Succesful(ResponseDto response)
        {
            //Arrange
            var serviceMock = new Mock<IBookService>();
            var sut = new BookController(serviceMock.Object);
            serviceMock.Setup(s => s.AddBook(It.IsAny<Book>())).Returns(response);

            //Act
            var testResponse = sut.AddBook(It.IsAny<Book>());

            //Assert
            Assert.Equal(testResponse.Value, response);
        }

        [Theory, CustomBookData]
        public void Service_GetBook_GetsBook_Succesful(Book book)
        {
            //Arrange
            var serviceMock = new Mock<IBookService>();
            var sut = new BookController(serviceMock.Object);
            serviceMock.Setup(s => s.GetBook(It.IsAny<string>())).Returns(book);

            //Act
            var testResponse = sut.GetBooks(It.IsAny<string>());

            //Assert
            Assert.Equal(testResponse.Value, book);
        }

        #endregion

        #region BookService Failure Tests

        [Theory, CustomResponseDtoFailureAttribute]
        public void Service_AddBook_AddsBook_Failure(ResponseDto response)
        {
            //Arrange
            var serviceMock = new Mock<IBookService>();
            var sut = new BookController(serviceMock.Object);
            serviceMock.Setup(s => s.AddBook(It.IsAny<Book>())).Returns(response);

            //Act
            var testResponse = sut.AddBook(It.IsAny<Book>());

            //Assert
            Assert.Equal(testResponse.Value, response);
        }

        [Theory, CustomBookDataFailureAttribute]
        public void Service_GetBook_GetsBook_Failure(Book book)
        {
            //Arrange
            var serviceMock = new Mock<IBookService>();
            var sut = new BookController(serviceMock.Object);
            serviceMock.Setup(s => s.GetBook(It.IsAny<string>())).Returns(book);

            //Act
            var testResponse = sut.GetBooks(It.IsAny<string>());

            //Assert
            Assert.Equal(testResponse.Value, book);
        }

        #endregion

        #region UserService Success Tests

        [Theory, CustomResponseDto]
        public void Service_Login_Logsin_Successful(ResponseDto response, UserDto user)
        {
            //Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(s => s.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(response);

            //Act
            var testResponse = sut.Login(user);

            //Assert
            Assert.Equal(testResponse.Value, response);
        }

        [Theory, CustomResponseDto]
        public void Service_Signup_Signups_Successful(ResponseDto response, UserDto user)
        {
            //Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(s => s.Signup(It.IsAny<string>(), It.IsAny<string>())).Returns(response);

            //Act
            var testResponse = sut.Signup(user);

            //Assert
            Assert.Equal(testResponse.Value, response);
        }

        #endregion

        #region UserService Failure Tests

        [Theory, CustomResponseDtoUserF]
        public void Service_Login_Logsin_Failure(ResponseDto response, UserDto user)
        {
            //Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(s => s.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(response);

            //Act
            var testResponse = sut.Login(user);

            //Assert
            Assert.IsType<BadRequestObjectResult>(testResponse.Result);
        }

        [Theory, CustomResponseDtoUserF]
        public void Service_Signup_Signups_Failure(ResponseDto response, UserDto user)
        {
            //Arrange
            var serviceMock = new Mock<IUserService>();
            var sut = new UserController(serviceMock.Object);
            serviceMock.Setup(s => s.Signup(It.IsAny<string>(), It.IsAny<string>())).Returns(response);

            //Act
            var testResponse = sut.Signup(user);

            //Assert
            Assert.IsType<BadRequestObjectResult>(testResponse.Result);
        }

        #endregion
    }
}