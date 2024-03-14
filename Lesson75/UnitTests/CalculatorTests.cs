using Task1.Class;

namespace UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void Addition_ReturnsCorrectValue()
        {
            // Arrange
            var mathOperations = new MathOperations();
            double a = 3;
            double b = 7;

            // Act
            double result = mathOperations.Addition(a, b);

            // Assert
            Assert.Equal(10, result);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(10, -10, 0)]
        public void Addition_ReturnsMultipleCorrectValues(double a, double b, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.Addition(a, b);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(2, 3, -1)]
        [InlineData(10, -10, 20)]
        public void Subtraction_ReturnsMultipleCorrectValues(double a, double b, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.Subtraction(a, b);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(2, 3, 6)]
        [InlineData(10, -10, -100)]
        public void Multiplication_ReturnsMultipleCorrectValues(double a, double b, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.Multiplication(a, b);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(1, 2, 0.5)]
        [InlineData(3, 5, 0.6)]
        [InlineData(10, -10, -1)]
        [InlineData(10, 0, 0)]
        public void Division_ReturnsMultipleCorrectValues(double a, double b, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.Division(a, b);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(2, 4)]
        [InlineData(5, 25)]
        [InlineData(-10, 100)]
        public void PowerOf2_ReturnsMultipleCorrectValues(double a, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.PowerOf2(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(100, 10)]
        [InlineData(-10, double.NaN)]
        public void SquareRoot_ReturnsMultipleCorrectValues(double a, double expectedValue)
        {
            // Arrange
            var mathOperations = new MathOperations();

            // Act
            var result = mathOperations.SquareRoot(a);

            // Assert
            Assert.Equal(expectedValue, result);
        }
    }
}