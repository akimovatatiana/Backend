using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class Program
    {
        public const string InvalidArgumentsCount = "Incorrect number of arguments! Usage PasswordStrength.exe <password>";
        public const string EmptyStringMessage = "Identifier must not be an empty string";
        public const string NotLetterOrNotDigitMessage = "Identifier must not have a non-letter or non-digit symbol";
        public static string GetPassword(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception(InvalidArgumentsCount);
            }
            return args[0];
        }
        public static bool CheckDigit(char ch)
        {
            return ch >= '0' && ch <= '9';
        }
        public static bool CheckLowerCase(char ch)
        {
            return ch >= 'a' && ch <= 'z';
        }
        public static bool CheckUpperCase(char ch)
        {
            return ch >= 'A' && ch <= 'Z';
        }
        public static bool CheckPassword(string password)
        {
            if (password == "")
            {
                Console.WriteLine(EmptyStringMessage);
                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (!CheckLowerCase(password[i]) && !CheckUpperCase(password[i]) && !CheckDigit(password[i]))
                {
                    Console.WriteLine(NotLetterOrNotDigitMessage);
                    return false;
                }
            }
            return true;
        }
        public static int CheckDuplicates(string str)
        {
            int numberOfDuplicates = 0;
            Dictionary<char, int> charDictionary = new Dictionary<char, int>();
            foreach (char ch in str)
            {
                if (charDictionary.ContainsKey(ch))
                {
                    charDictionary[ch]++;
                }
                else
                {
                    charDictionary.Add(ch, 1);
                }
            }
            foreach (var i in charDictionary)
            {
                if (i.Value > 1)
                {
                    numberOfDuplicates += i.Value;
                }
            }
            return numberOfDuplicates;
        }
        public static int CalculateStrength(string password, int numberOfDigits, int numberOfLowerCase, int numberOfUpperCase, int numberOfDuplicates)
        {
            int strength = 0;
            int passwordLength = password.Length;
            strength += 4 * passwordLength;
            if (numberOfDigits != 0)
            {
                strength += 4 * numberOfDigits;
            }
            if (numberOfUpperCase != 0)
            {
                strength += (passwordLength - numberOfUpperCase) * 2;
            }
            if (numberOfLowerCase != 0)
            {
                strength += (passwordLength - numberOfLowerCase) * 2;
            }
            if ((numberOfLowerCase == 0 && numberOfUpperCase == 0) || numberOfDigits == 0)
            {
                strength -= passwordLength;
            }
            strength -= numberOfDuplicates;

            return strength;
        }
        public static int GetPasswordStrength(string password)
        {
            int numberOfDigits = 0;
            int numberOfLowerCase = 0;
            int numberOfUpperCase = 0;
            int numberOfDuplicates = CheckDuplicates(password);
            for (int i = 0; i < password.Length; i++)
            {
                if (CheckDigit(password[i]))
                {
                    numberOfDigits++;
                }
                if (CheckLowerCase(password[i]))
                {
                    numberOfLowerCase++;
                }
                if (CheckUpperCase(password[i]))
                {
                    numberOfUpperCase++;
                }
            }
            int strength = CalculateStrength(password, numberOfDigits, numberOfLowerCase, numberOfUpperCase, numberOfDuplicates);
            return strength;
        }
        public static void Main(string[] args)
        {
            try
            {
                string password = GetPassword(args);
                if (CheckPassword(password))
                {
                    int passwordStrength = GetPasswordStrength(password);
                    Console.WriteLine(passwordStrength);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: " + InvalidArgumentsCount);
            }
        }
    }
}
