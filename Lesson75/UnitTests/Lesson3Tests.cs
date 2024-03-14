using Task1.Class;

namespace UnitTests
{
    public class Lesson3Tests
    {
        #region Lesson3Task2

        [Theory]
        [InlineData(1, "The number 1 does not meet any conditions")]
        [InlineData(2, "The number 2 is even")]
        [InlineData(10, "The number 10 is even")]
        public void Lesson3Task2Subtask1_ReturnsMultipleCorrectValues(int a, string expectedValue)
        {
            // Arrange
            Lesson3Task2 lesson3Task2 = new();

            // Act
            var result = lesson3Task2.SubTask1(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(1, "Cool")]
        [InlineData(2, "Cool")]
        [InlineData(10, "Cool")]
        public void Lesson3Task2Subtask2_ReturnsMultipleCorrectValues(int a, string expectedValue)
        {
            // Arrange
            Lesson3Task2 lesson3Task2 = new();

            // Act
            var result = lesson3Task2.SubTask2(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        #endregion

        #region Lesson3Task3

        [Theory]
        [InlineData(1, "Good morning!")]
        [InlineData(15, "Good afternoon!")]
        [InlineData(10, "Good morning!")]
        public void Lesson3Task3Subtask1_ReturnsMultipleCorrectValues(int a, string expectedValue)
        {
            // Arrange
            Lesson3Task3 lesson3Task3 = new();

            // Act
            var result = lesson3Task3.SubTask1(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("Laikinas123", "You have successfully logged in")]
        [InlineData("01101001 01101110", "Hacked..")]
        [InlineData("10", "Password is incorrect, please try again..")]
        public void Lesson3Task3Subtask2_ReturnsMultipleCorrectValues(string a, string expectedValue)
        {
            // Arrange
            Lesson3Task3 lesson3Task3 = new();

            // Act
            var result = lesson3Task3.SubTask2(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        #endregion
    }
}
