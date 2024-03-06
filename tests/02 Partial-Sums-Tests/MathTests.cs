namespace _02_Partial_Sums_Tests
{
    using _02_Partial_Sums;

    public class MathTests
    {
        [Fact]
        public void GetRowSumsTest()
        {
            // Arrange
            var rows = new List<double> { 1, 2, 3, 4 };
            var expected = new List<double> { 1, 3, 6, 10 };

            // Act
            var actual = Math.GetRowSums(rows);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}