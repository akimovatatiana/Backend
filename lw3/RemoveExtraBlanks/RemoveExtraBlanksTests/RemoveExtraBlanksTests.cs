using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveExtraBlanksTests
    {
        [TestMethod]
        public void RemoveExtraBlanks_WithEmptyString_ShouldReturnEmptyString()
        {
            string line = "";
            string resLine = RemoveExtraBlanks.Program.RemoveExtraBlanksAndTabs(line);
            string expectedLine = "";
            Assert.AreEqual(expectedLine, resLine);
        }
        [TestMethod]
        public void RemoveExtraBlanks_WithStringStartsWithBlanks_ShouldReturnStringWithoutBlanksInTheBeginning()
        {
            string line = "     some string with extra spaces";
            string resLine = RemoveExtraBlanks.Program.RemoveExtraBlanks(line);
            string expectedLine = "some string with extra spaces";
            Assert.AreEqual(expectedLine, resLine);
        }
        [TestMethod]
        public void RemoveExtraBlanks_WithStringEndsWithBlanks_ShouldReturnStringWithoutBlanksInTheEnd()
        {
            string line = "some string with extra spaces      ";
            string resLine = RemoveExtraBlanks.Program.RemoveExtraBlanks(line);
            string expectedLine = "some string with extra spaces";
            Assert.AreEqual(expectedLine, resLine);
        }
        [TestMethod]
        public void RemoveExtraBlanks_WithStringWithTab_ShouldReturnStringWithSpace()
        {
            string line = "some \tstring";
            string resLine = RemoveExtraBlanks.Program.RemoveExtraBlanks(line);
            string expectedLine = "some string";
            Assert.AreEqual(expectedLine, resLine);
        }
        [TestMethod]
        public void RemoveExtraBlanksAndTabs_WithRepetitiveBlanks_ShouldReturnStringWithoutExtraBlanks()
        {
            string line = "some   string    with     extra  spaces";
            string resLine = RemoveExtraBlanks.Program.RemoveExtraBlanksAndTabs(line);
            string expectedLine = "some string with extra spaces";
            Assert.AreEqual(expectedLine, resLine);
        }
    }
}
