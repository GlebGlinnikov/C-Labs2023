namespace Lab1.Tests
{
    public class Part1tests
    {
        [Theory]
        [InlineData(0, -10)]
        public void IsWrongLengthVectorCreatingFailed(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Part1(a));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Part1(b));
        }

        [Fact]
        public void IsVectorContainsNegatives()
        {
            var firstPart = new Part1(100);
            Assert.Contains(firstPart.Vector, p => p < 0);
        }

        [Fact]
        public void IsProductValid()
        {
            var firstPart = new Part1(100);
            Assert.Equal(firstPart.product_of_neg(), firstPart.Vector.Where(i => i < 0).Aggregate((double acc, double val) => acc * val));
        }

        [Fact]
        public void IsSumValid()
        {
            var firstPart = new Part1(100);
            var arr = firstPart.Vector.ToList();

            Assert.Equal(firstPart.sum_of_pos(), arr.TakeWhile((n) => arr.IndexOf(n) < arr.IndexOf(arr.Max())).Where((n) => n > 0).Aggregate((a, n) => a + n));
        }
    }
}