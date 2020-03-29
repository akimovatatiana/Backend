using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public const string InvalidArgumentsCount = "Incorrect number of arguments! Usage RemoveExtraBlanks.exe <input.txt> <output.txt>";
        public static string RemoveExtraBlanks(string text)
        {
            text = text.Trim();
            return RemoveExtraBlanksAndTabs(text);
        }
        public static string RemoveExtraBlanksAndTabs(string line)
        {
             Regex regex = new Regex(@"[ , \t]+");
             return regex.Replace(line, " ");
        }
        public static void ReadAndWriteFiles(string inputFileName, string outputFileName)
        {
            StreamWriter outputFile = new StreamWriter(outputFileName);
            StreamReader inputFile = new StreamReader(inputFileName);
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                line = RemoveExtraBlanks(line);
                outputFile.WriteLine(line);
            }
            inputFile.Close();
            outputFile.Close();
        }
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine(InvalidArgumentsCount);
                return;
            }
            string inputFileName = args[0];
            string outputFileName = args[1];
            if (!File.Exists(inputFileName))
            {
                Console.WriteLine("Failed to open file for reading " + inputFileName);
                return;
            }
            ReadAndWriteFiles(inputFileName, outputFileName);  
        }
    }
}
