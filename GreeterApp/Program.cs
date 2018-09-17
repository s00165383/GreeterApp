using System;

namespace GreeterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeter is a terminal application that greets old friends warmly,
            //and remembers new friends.

            //Display a title bar.
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\t***  Greeter - Hello old and new friends!  ***");
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\nWelcome to Library.");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1. Enter a name.");
            Console.WriteLine("2. See a list of all users.");
            Console.WriteLine("3. Quit.");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.WriteLine("Case 1");
                    break;
                case "2":
                    Console.WriteLine("Case 2");
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Unknown selection");
                break;
            }
            } 
    }
}
