using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void CheckDigit_WithNumber_ShouldReturnTrue()
        {
            char number = '1';
            bool res = CheckIdentifier.Program.CheckDigit(number);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckDigit_WithNotNumber_ShouldReturnFalse()
        {
            char notNumber = 'a';
            bool res = CheckIdentifier.Program.CheckDigit(notNumber);
            Assert.AreEqual(false, res);
        }
        [TestMethod]
        public void CheckLetter_WithLetter_ShouldReturnTrue()
        {
            char letter = 'a';
            bool res = CheckIdentifier.Program.CheckLetter(letter);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckLetter_WithNotLetter_ShouldReturnFalse()
        {
            char notLetter = '5';
            bool res = CheckIdentifier.Program.CheckLetter(notLetter);
            Assert.AreEqual(false, res);
        }
        [TestMethod]
        public void GetIdentifier_WithMoreThanOneArgument_ShouldThrowException()
        {
            string[] twoArgs =  { "ff", "dsd" };
            try
            {
                CheckIdentifier.Program.GetIdentifier(twoArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, CheckIdentifier.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void GetIdentifier_WithNoArgument_ShouldThrowException()
        {
            string[] noArgs = { };
            try
            {
                CheckIdentifier.Program.GetIdentifier(noArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, CheckIdentifier.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void CheckIdentifierOnSR3_WithStartsWithDigitIdentifier_ShouldReturnFalse()
        {
            string startsWithDigitIdentifier = "1hello";
            bool result = CheckIdentifier.Program.CheckIdentifierOnSR3(startsWithDigitIdentifier);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckIdentifierOnSR3_WithStartsWithNotLetterIdentifier_ShouldReturnFalse()
        {
            string startsWithNotLetterIdentifier = "-hello";
            bool result = CheckIdentifier.Program.CheckIdentifierOnSR3(startsWithNotLetterIdentifier);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckIdentifierOnSR3_WithEmptyIdentifier_ShouldReturnFalse()
        {
            string emptyStringIdentifier = "";
            bool result = CheckIdentifier.Program.CheckIdentifierOnSR3(emptyStringIdentifier);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckIdentifierOnSR3_WithNotDigitOrNotLetterIdentifier_ShouldReturnTrue()
        {
            string wrongIdentifier = "he_34g";
            bool result = CheckIdentifier.Program.CheckIdentifierOnSR3(wrongIdentifier);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckIdentifierOnSR3_WithRightIdentifier_ShouldReturnTrue()
        {
            string rightIdentifier = "Hello25";
            bool result = CheckIdentifier.Program.CheckIdentifierOnSR3(rightIdentifier);
            Assert.AreEqual(true, result);
        }
    }
}
