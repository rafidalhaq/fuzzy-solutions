using IGS.MathExtensions;
using Xunit;

namespace MathExtensionsTests
{
    public class BinaryOperationsTests
    {
        [Fact]
        public void TestTruncation()
        {
            Assert.Equal(1, MathExtensions.Truncation(3, 4));
            Assert.Equal(1, MathExtensions.Truncation(4, 4));
            Assert.Equal(3, MathExtensions.Truncation(4, 3));
        }

        [Fact]
        public void TestLaxTruncation()
        {
            Assert.Equal(1, MathExtensions.LaxTruncation(3, 4));
            Assert.Equal(4, MathExtensions.LaxTruncation(4, 4));
            Assert.Equal(3, MathExtensions.LaxTruncation(4, 3));
        }
    }
}
