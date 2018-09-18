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
            string lineIn;  // variable where data from file is stored
            string[] fields = new string[3];
            FileStream fs;



            //Display a title bar.
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\t***  Greeter - Hello old and new friends!  ***");
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\nWelcome to Library.");
            Boolean exit = false;
            do
            {
                //Reading from file
                fs = new FileStream("friends.txt", FileMode.Open, FileAccess.Read);
                StreamReader inputStream = new StreamReader(fs);
                lineIn = inputStream.ReadLine();

                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Check if a friend exists.");
                Console.WriteLine("2. See a list of all friends.");
                Console.WriteLine("3. Add a friend.");
                Console.WriteLine("4. Quit.\n");
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
                                if (exists)
                                {
                                    Console.WriteLine("Welcome back {0}", fields[0]);
                                    Console.WriteLine("\nWould you like to edit this friends details? (Y/N)");
                                    string editChoice = Console.ReadLine();
                                    if(editChoice == "Y")
                                    Console.WriteLine("Edit choice.");
                                }

                            }
                            lineIn = inputStream.ReadLine();
                        }
                            if(!exists)
                                Console.WriteLine("A new friend, yayy");

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
                        Console.WriteLine("Enter new friends name");
                        string newName = Console.ReadLine();
                        Console.WriteLine("Enter where friend lives");
                        string newLocation = Console.ReadLine();
                        Console.WriteLine("Enter new friends number");
                        string newNumber = Console.ReadLine();
                        inputStream.Close();
                        //Writing to file
                        FileStream wfs = new FileStream("friends.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter outputStream = new StreamWriter(wfs);
                        outputStream.WriteLine("{0},{1},{2}", newName, newLocation, newNumber);
                        outputStream.Close();
                        wfs.Close();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Unknown selection");
                        break;
                }
                inputStream.Close();
            } while (!exit);
        }
    }
}
