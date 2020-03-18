using System;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Number of arguments: " + args.Length);
                Console.Write("Arguments: ");
                for (int i = 0; i < args.Length; i++)
                    Console.Write(args[i] + " ");
            }
            else
            {
                Console.WriteLine("No parameters were specified!");
            }
        }
    }
}