using System;

namespace CheckIdentifier
{
    public class Program
    {
        public const string NoMessage = "No";
        public const string YesMessage = "Yes";
        public const string InvalidArgumentsCount = "Incorrect number of arguments! Usage CheckIdentifier.exe <identifier>";
        public const string EmptyStringMessage = "Identifier must not be an empty string";
        public const string StartsWithDigitSymbolMessage = "Identifier must not start with a digit symbol";
        public const string StartsWithNotLetterSymbolMessage = "Identifier must not start with a non-letter symbol";
        public const string NotLetterOrNotDigitMessage = "Identifier must not have a non-letter or non-digit symbol";
        public static bool CheckDigit(char ch)
        {
            if (!char.IsDigit(ch))
            {
                return false;
            }
            return true;
        }
        public static bool CheckLetter(char ch)
        {
            if (!char.IsLetter(ch))
            {
                return false;
            }
            return true;
        }
        public static string GetIdentifier(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception(InvalidArgumentsCount);
            }
            return args[0];
        }
        public static bool CheckIdentifierOnSR3(string identifier)
        {
            if (identifier == "")
            {
                Console.WriteLine(EmptyStringMessage);
                return false;
            }
            if (CheckDigit(identifier[0]))
            {
                Console.WriteLine(StartsWithDigitSymbolMessage);
                return false;
            }
            if (!CheckLetter(identifier[0]))
            {
                Console.WriteLine(StartsWithNotLetterSymbolMessage);
                return false;
            }
            else
            {
                for (int i = 1; i < identifier.Length; i++)
                {
                    if (!CheckLetter(identifier[i]) && !CheckDigit(identifier[i]))
                    {
                        Console.WriteLine(NotLetterOrNotDigitMessage);
                        return false;
                    }
                }
                return true;
            }
        
        }
        public static void Main(string[] args)
        {
            try
            {
                string identifier = GetIdentifier(args);
                if (CheckIdentifierOnSR3(identifier))
                {
                    Console.WriteLine(YesMessage);
                }
                else
                {
                    Console.WriteLine(NoMessage);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: " + InvalidArgumentsCount);
            }

        }
    }
}
