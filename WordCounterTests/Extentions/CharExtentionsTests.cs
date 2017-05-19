using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WordCounter.Extentions.Tests
{
    [TestClass()]
    public class CharExtentionsTests
    {
        [TestMethod()]
        public void IsWordPartTest()
        {
            // Arrange.
            string wordChars = "1234567890qwertyuiopasdfghjklzxcvbnmйцукенгшщзхъфывапролджэячсмитьбю-_";
            string notWordChars = " \t\n\r?.,[]{}'\";!@#$%^&*()/=+";

            // Act + assert.
            foreach (var charItem in wordChars.ToCharArray())
            {
                Assert.IsTrue(charItem.IsWordPart());
            }

            foreach (var charItem in notWordChars.ToCharArray())
            {
                Assert.IsFalse(charItem.IsWordPart());
            }
        }
    }
}