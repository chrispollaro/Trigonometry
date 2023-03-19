using FluentAssertions;

namespace Trigonometry.Tests.Unit
{
    public class TriangleTests
    {
        private const double NinetyInRadians = Math.PI / 2;
        private const double FortyFiveInRadians = Math.PI / 4;
        private const double SixtyInRadians = Math.PI / 3;
        private const double TwoPI = Math.PI * 2;

        [Fact]
        public void FindAllSidesLength_ShouldCalculateLengths()
        {
            // Arrange
            Point a = new Point { X = 0, Y = 0 };
            Point b = new Point { X = 3, Y = 0 };
            Point c = new Point { X = 3, Y = 4 };

            var sut = new Triangle
            {
                A = a,
                B = b,
                C = c
            };

            // Act
            sut.FindAllSidesLength();

            // Assert
            sut.LenAB.Should().BeApproximately(3, 0.1);
            sut.LenBC.Should().BeApproximately(4, 0.1);
            sut.LenAC.Should().BeApproximately(5, 0.1);
        }

        [Fact]
        public void ConstructorWithThreePoints_ShouldCalculateLengths()
        {
            // Arrange
            Point a = new() { X = 0, Y = 0 };
            Point b = new() { X = 3, Y = 0 };
            Point c = new() { X = 3, Y = 4 };

            // Act
            Triangle sut = new Triangle(a, b, c);
             
            // Assert
            sut.LenAB.Should().BeApproximately(3, 0.1);
            sut.LenBC.Should().BeApproximately(4, 0.1);
            sut.LenAC.Should().BeApproximately(5, 0.1);
        }

        [Fact]
        public void CalculateAngles_ShouldCalculateAllAngles()
        {
            // Arrange
            Point a = new Point { X = 0, Y = 0 };
            Point b = new Point { X = 3, Y = 0 };
            Point c = new Point { X = 3, Y = 4 };

            var sut = new Triangle();
            sut.A = a;
            sut.B = b;
            sut.C = c;

            // Act
            sut.CalculateAngles();

            // Assert
            sut.AngA.Should().BeInRange(0, TwoPI);
            sut.AngA.Should().BeApproximately(0.927, 0.001);
            sut.AngB.Should().BeInRange(0, TwoPI);
            sut.AngB.Should().BeApproximately(1.570, 0.001);
            sut.AngC.Should().BeInRange(0, TwoPI);
            sut.AngC.Should().BeApproximately(0.643, 0.001);
        }

        [Fact]
        public void ConstructorWithThreePoints_ShouldCalculateAngles()
        {
            // Arrange
            Point a = new() { X = 0, Y = 0 };
            Point b = new() { X = 3, Y = 0 };
            Point c = new() { X = 3, Y = 4 };


            // Act
            Triangle sut = new(a, b, c);

            // Assert
            sut.AngA.Should().BeInRange(0, TwoPI);
            sut.AngA.Should().BeApproximately(0.927, 0.001);
            sut.AngB.Should().BeInRange(0, TwoPI);
            sut.AngB.Should().BeApproximately(1.570, 0.001);
            sut.AngC.Should().BeInRange(0, TwoPI);
            sut.AngC.Should().BeApproximately(0.643, 0.001);
        }

        [Theory]
        [InlineData(NinetyInRadians, 90.0)]
        [InlineData(SixtyInRadians, 60.0)]
        [InlineData(FortyFiveInRadians, 45.0)]
        public void ConvertFromRadsToDegs_WithParamOneInRads_ShouldReturnDegrees(double subject, double expectedResult)
        {
            // Arrange
            
            // Act
            var result = Triangle.ConvertFromRadsToDegs(subject);

            // Assert
            result.Should().BeApproximately(expectedResult, 0.00001);
        }

        [Theory]
        [InlineData(90.0, NinetyInRadians)]
        [InlineData(60.0, SixtyInRadians)]
        [InlineData(45.0, FortyFiveInRadians)]
        public void ConvertFromDegsToRads_WithParamOneInDegs_ShouldReturnRads(double subject, double expectedResult)
        {
            // Arrange

            // Act
            var result = Triangle.ConvertFromDegsToRads(subject);

            // Assert
            result.Should().BeApproximately(expectedResult, 0.00001);
        }
    }
}