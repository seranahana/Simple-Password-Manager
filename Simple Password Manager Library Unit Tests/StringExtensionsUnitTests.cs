using Xunit;

namespace SimplePM.Library.Tests
{
    public class StringExtensionsUnitTests
    {
        [Fact]
        public void TestAlphabeticPasswords()
        {
            // Arrange (размещение)
            string alphabeticPassword = "password";
            bool expected = false;

            // Act (действие)
            bool actual = alphabeticPassword.IsReliablePassword();

            // Assert (утверждение)
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNumericPasswords()
        {
            // Arrange
            string numericPassword = "1234567890";
            bool expected = false;

            // Act
            bool actual = numericPassword.IsReliablePassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSymbolicPasswords()
        {
            // Arrange
            string symbolicPassword = "*&^%$#@!";
            bool expected = false;

            // Act
            bool actual = symbolicPassword.IsReliablePassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestNullArgument()
        {
            // Arrange
            string nullString = null;
            bool expected = false;

            // Act
            bool actual = nullString.IsReliablePassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestEmptyString()
        {
            // Arrange
            string emptyString = string.Empty;
            bool expected = false;

            // Act
            bool actual = emptyString.IsReliablePassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("H08Pj|.mD=.k;>Mp")]
        [InlineData("]X(r3lM0\"^.kz@xn")]
        [InlineData("pVb0BJ5v>b!M!)]")]
        [InlineData("YUnZnMU-dG6x8Ab*")]
        public void TestReliablePasswords(string reliablePassword)
        {
            // Arrange
            bool expected = true;

            // Act
            bool actual = reliablePassword.IsReliablePassword();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
