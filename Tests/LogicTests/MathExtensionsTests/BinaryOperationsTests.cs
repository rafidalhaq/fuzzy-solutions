using IGS.MathExtensions.Binary;
using Xunit;

namespace MathExtensionsTests
{
    public class BinaryOperationsTests
    {
        [Fact]
        public void TestTruncation()
        {
            Assert.Equal(1, BinaryExtensions.Truncation(3, 4));
            Assert.Equal(1, BinaryExtensions.Truncation(4, 4));
            Assert.Equal(3, BinaryExtensions.Truncation(4, 3));
        }

        [Fact]
        public void TestLaxTruncation()
        {
            Assert.Equal(1, BinaryExtensions.LaxTruncation(3, 4));
            Assert.Equal(4, BinaryExtensions.LaxTruncation(4, 4));
            Assert.Equal(3, BinaryExtensions.LaxTruncation(4, 3));
        }
    }
}
