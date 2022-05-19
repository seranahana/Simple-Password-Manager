using System;
using Xunit;

namespace SimplePM.Library.Tests
{
    public class PasswordGeneratorUnitTests
    {
        [Theory]
        [InlineData(10)]
        [InlineData(23)]
        [InlineData(44)]
        [InlineData(76)]
        [InlineData(99)]
        public void TestRequiredGeneratedPasswordLength(int length)
        {
            int expected = length;

            int actual = PasswordGenerator.GenerateReliable(length).Length;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(0)]
        public void TestEdgePasswordLength(int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => PasswordGenerator.GenerateReliable(length));
        }

        [Fact]
        public void TestGenerationTimeout()
        {
            int length = 2;
            
            Assert.Throws<TimeoutException>(() => PasswordGenerator.GenerateReliable(length));
        }
    }
}
