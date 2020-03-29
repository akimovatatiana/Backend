using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class GetPasswordTests
    {
        [TestMethod]
        public void GetPassword_WithMoreThanOneArgument_ShouldThrowException()
        {
            string[] twoArgs = { "ff", "dsd" };
            try
            {
                PasswordStrength.Program.GetPassword(twoArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, PasswordStrength.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void GetPassword_WithNoArgument_ShouldThrowException()
        {
            string[] noArgs = { };
            try
            {
                PasswordStrength.Program.GetPassword(noArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, PasswordStrength.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
    [TestClass]
    public class CheckLetterAndCheckDigitTests
    {
        [TestMethod]
        public void CheckDigit_WithNumber_ShouldReturnTrue()
        {
            char number = '1';
            bool res = PasswordStrength.Program.CheckDigit(number);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckLowerCase_WithLowerCaseLetter_ShouldReturnTrue()
        {
            char letter = 'a';
            bool res = PasswordStrength.Program.CheckLowerCase(letter);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void CheckUpperCase_WithUpperCaseLetter_ShouldReturnTrue()
        {
            char letter = 'A';
            bool res = PasswordStrength.Program.CheckUpperCase(letter);
            Assert.AreEqual(true, res);
        }
    }
    [TestClass]
    public class CheckPasswordTests
    {
        [TestMethod]
        public void CheckPassword_WithEmptyPassword_ShouldReturnFalse()
        {
            string emptyString = "";
            bool result = PasswordStrength.Program.CheckPassword(emptyString);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckPassword_WithNotDigitOrNotLetterPassword_ShouldReturnTrue()
        {
            string wrongPassword = "he_34g";
            bool result = PasswordStrength.Program.CheckPassword(wrongPassword);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void CheckPassword_WithRightPassword_ShouldReturnTrue()
        {
            string rightPassword = "Abcd1a";
            bool result = PasswordStrength.Program.CheckPassword(rightPassword);
            Assert.AreEqual(true, result);
        }
    }
    [TestClass]
    public class CheckDuplicatesTests
    {
        [TestMethod]
        public void CheckDupticates_WithStringWithDuplicates_ShouldReturnNumberOfDuplicates()
        {
            string str = "abcd1a";
            int resultNumber = PasswordStrength.Program.CheckDuplicates(str);
            int expectedNumber = 2;
            Assert.AreEqual(expectedNumber, resultNumber);
        }
        [TestMethod]
        public void CheckDupticates_WithStringWithoutDuplicates_ShouldReturnZero()
        {
            string str = "abcd1";
            int resultNumber = PasswordStrength.Program.CheckDuplicates(str);
            int expectedNumber = 0;
            Assert.AreEqual(expectedNumber, resultNumber);
        }
    }
    [TestClass]
    public class GetPasswordStrengthTests
    {
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyNumbers()
        {
            string password = "123";
            int expectedStrength = 21;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyLowerCase()
        {
            string password = "abcd";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithOnlyUpperCase()
        {
            string password = "ABCD";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithSomeUpperCase()
        {
            string password = "aBCd";
            int expectedStrength = 20;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithNumbersAndLowerCaseLetters()
        {
            string password = "ab12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithNumbersAndUpperCaseLetters()
        {
            string password = "AB12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithPasswordWithDuplicates()
        {
            string password = "abcd1a";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void GetPasswordStrength_WithStrongPassword()
        {
            string password = "ab12NeO";
            int expectedStrength = 54;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
    }
}