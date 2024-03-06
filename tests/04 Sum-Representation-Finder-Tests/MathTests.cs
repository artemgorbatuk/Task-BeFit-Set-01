namespace _04_Sum_Representation_Finder_Tests
{
    using _04_Sum_Representation_Finder;

    public class MathTests
    {
        [Theory]
        //[InlineData(null, 0, true)]
        //[InlineData(new[] { 3, 1, 8, 5 }, 7, false)]
        [InlineData(new[] { 3, 1, 8, 5, 4 }, 10, true)]
        [InlineData(new[] { 3, 1, 8, 5, 4 }, 2, false)]
        public void CanSumTest(int[] numbers, int sum, bool expected)
        {
            var actual = Math.CanSum(numbers, sum);

            Assert.Equal(expected, actual);
        }
    }
}