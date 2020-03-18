using System;

namespace remove_duplicates
{
    class Program
    {
        static string RemoveDuplicateChars(string str)
        {
            for (int i = 0; i < str.Length - 1; i++)
            {
                string symbol = str[i].ToString();
                str = str.Replace(symbol, "");
                str = str.Insert(i, symbol);
            }
            return str;
        }
        static void Main(string[] args)
        {
            string inputString = "";
            if (args.Length == 1)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    inputString += args[i];
                }
                string resString = RemoveDuplicateChars(inputString);
                Console.WriteLine(resString);
            }
            else
            {
                Console.WriteLine("Incorrect number of arguments!" + "\n" + "Usage remove_duplicates.exe <input string>");
            }
        }
    }
}
