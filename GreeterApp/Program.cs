using System;
using System.IO;

namespace GreeterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeter is a terminal application that greets old friends warmly,
            //and remembers new friends.
            FileStream fs = new FileStream("friends.txt", FileMode.Open, FileAccess.Read);

            StreamReader inputStream = new StreamReader(fs);

            string lineIn;  // variable where data from file is stored
            string[] fields = new string[3];

            lineIn = inputStream.ReadLine();


            //while (lineIn != null)
            //{
            //    Console.WriteLine(lineIn);
            //    lineIn = inputStream.ReadLine();
            //}


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
                    Console.WriteLine("Enter a name");
                    string selectedName = Console.ReadLine();
                    Boolean exists = false;
                    while (lineIn != null)
                    {
                        fields = lineIn.Split(',');
                        if (fields[0] == selectedName)
                        {
                            exists = true;
                            break;
                        }
                        lineIn = inputStream.ReadLine();
                    }
                    if (exists)
                        Console.WriteLine("Welcome back {0}", fields[0]);
                    else
                        Console.WriteLine("A new user, yayy");
                    break;
                case "2":
                    while (lineIn != null)
                    {
                        fields = lineIn.Split(',');
                        Console.WriteLine(fields[0]);
                        lineIn = inputStream.ReadLine();
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Unknown selection");
                    break;
            }
            inputStream.Close();
        }
    }
}
