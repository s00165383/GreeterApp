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
                Console.WriteLine("2. See a list of all friends and their details.");
                Console.WriteLine("3. Add a friend.");
                Console.WriteLine("4. Delete friend");
                Console.WriteLine("5. Update friends details");
                Console.WriteLine("6. Quit.\n");
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
                                }

                            }
                            lineIn = inputStream.ReadLine();
                        }
                        if (!exists)
                            Console.WriteLine("A new friend, yayy");

                        break;
                    case "2":
                        Console.WriteLine("Name\t\tLocation\t\tPhone");
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            Console.WriteLine("{0}\t\t{1}\t\t\t{2}", fields[0], fields[1], fields[2]);
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
                        Console.WriteLine("Delete 1");
                        Console.WriteLine("Enter a name");
                        selectedName = Console.ReadLine();
                        exists = false;
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            if (fields[0] == selectedName)
                            {
                                exists = true;
                            }
                            lineIn = inputStream.ReadLine();
                        };
                        string tempFile = Path.GetTempFileName();


                        fs.Position = 0;
                        StreamReader inputStream3 = new StreamReader(fs);
                        lineIn = inputStream3.ReadLine();
                        if (exists)
                        {
                            Console.WriteLine("\nWould you like to delete this friends details? (Y/N)");
                            string deleteChoice = Console.ReadLine();
                            while (lineIn != null)
                            {
                                fields = lineIn.Split(',');
                                //Writing to file
                                FileStream wfs2 = new FileStream(tempFile, FileMode.Append, FileAccess.Write);
                                StreamWriter outputStream2 = new StreamWriter(wfs2);

                                if (deleteChoice == "Y")
                                {
                                    if (fields[0] != selectedName)
                                    {
                                        outputStream2.WriteLine(lineIn);
                                    }

                                }
                                outputStream2.Close();
                                wfs2.Close();
                                lineIn = inputStream3.ReadLine();
                            }

                        }

                        
                        inputStream.Close();
                        File.Delete("friends.txt");
                        File.Move(tempFile, "friends.txt");


                        break;


                    case "5":
                        Console.WriteLine("Update 1");
                        Console.WriteLine("Enter a name");
                        selectedName = Console.ReadLine();
                        exists = false;
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            if (fields[0] == selectedName)
                            {
                                exists = true;
                            }
                            lineIn = inputStream.ReadLine();
                        };
                        string tempFile2 = Path.GetTempFileName();


                        fs.Position = 0;
                        StreamReader inputStream4 = new StreamReader(fs);
                        lineIn = inputStream4.ReadLine();
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            if (exists)
                            {
                                Console.WriteLine("\nWould you like to delete this friends details? (Y/N)");
                                string deleteChoice = Console.ReadLine();
                                if (deleteChoice == "Y")
                                {
                                    Console.WriteLine("Please re-enter your friends details");
                                    Console.WriteLine("Name");
                                    string updatedName = Console.ReadLine();
                                    Console.WriteLine("Location");
                                    string updatedLocation = Console.ReadLine();
                                    Console.WriteLine("Phone Number");
                                    string updatedNumber = Console.ReadLine();
                                    //Writing to file
                                    FileStream wfs2 = new FileStream(tempFile2, FileMode.Append, FileAccess.Write);
                                    StreamWriter outputStream2 = new StreamWriter(wfs2);
                                    if (fields[0] != selectedName)
                                    {
                                        outputStream2.WriteLine(lineIn);
                                    }
                                    else
                                        outputStream2.WriteLine("{0},{1},{2}", updatedName, updatedLocation, updatedNumber);
                                    outputStream2.Close();
                                    wfs2.Close();
                                }
                            lineIn = inputStream.ReadLine();
                            }
                            inputStream.Close();
                            File.Delete("friends.txt");
                            File.Move(tempFile2, "friends.txt");
                        }


                        break;




                    case "6":
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
