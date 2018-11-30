using System;
using System.IO;

namespace GreeterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Greeter is a terminal application that stores friends contact information
            string lineIn;  // variable where data from file is stored
            string[] fields = new string[5];
            FileStream fs;

            //Display a title bar.
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\t***  Welcome to Your Friend Library.  ***");
            Console.WriteLine("\t**********************************************");
            //Console.WriteLine("\nWelcome to Your Friend Library.");
            Boolean exit = false;
            do
            {
                //Reading from file
                fs = new FileStream("friends.txt", FileMode.Open, FileAccess.Read);
                StreamReader inputStream = new StreamReader(fs);
                lineIn = inputStream.ReadLine();

                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Check if a friend exists and see their details.");
                Console.WriteLine("2. See a list of all friends and their details.");
                Console.WriteLine("3. Add a friend.");
                Console.WriteLine("4. Delete a friend");
                Console.WriteLine("5. Update a friends details");
                Console.WriteLine("6. Quit.\n");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("Enter a name");
                        string selectedName = Console.ReadLine().ToUpper();
                        Boolean exists = false;
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            if (fields[0] == selectedName)
                            {
                                exists = true;
                                if (exists)
                                {
                                    Console.WriteLine("\nWe have a record for {0}", fields[0]);
                                    Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", "Name", "Address Line 1", "Address Line 2", "Address Line 3", "Phone Number");
                                    Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", fields[0], fields[1], fields[2], fields[3], fields[4]);
                                }

                            }
                            lineIn = inputStream.ReadLine();
                        }
                        if (!exists)
                            Console.WriteLine("\nThere is no record for {0}", selectedName);

                        break;
                    case "2":
                        //Console.WriteLine("Name\t\t\t\tAddress Line 1\t\tAddress Line 2\t\tAddress Line 3\t\tPhone");
                        Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", "Name","Address Line 1", "Address Line 2", "Address Line 3","Phone Number");
                        while (lineIn != null)
                        {
                            fields = lineIn.Split(',');
                            //Console.WriteLine("{0}\t\t\t{1}\t\t{2}\t\t\t{3}\t\t\t{4}", fields[0], fields[1], fields[2],fields[3], fields[4]);
                            Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", fields[0], fields[1], fields[2], fields[3], fields[4]);
                            lineIn = inputStream.ReadLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter new friends name");
                        string newName = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter new friends address line 1");
                        string AddressLine1 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter new friends address line 2");
                        string AddressLine2 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter new friends address line 3");
                        string AddressLine3 = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter new friends number");
                        string newNumber = Console.ReadLine().ToUpper();
                        inputStream.Close();
                        //Writing to file
                        FileStream wfs = new FileStream("friends.txt", FileMode.Append, FileAccess.Write);
                        StreamWriter outputStream = new StreamWriter(wfs);
                        outputStream.WriteLine("{0},{1},{2},{3},{4}", newName, AddressLine1, AddressLine2, AddressLine3, newNumber);
                        outputStream.Close();
                        wfs.Close();
                        break;
                    case "4":
                        Console.WriteLine("Enter a name");
                        selectedName = Console.ReadLine().ToUpper();
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
                            Console.WriteLine("\nWould you like to delete {0}'s details? (Y/N)", selectedName);
                            string deleteChoice = Console.ReadLine().ToUpper();
                            if (deleteChoice == "Y")
                            {
                                while (lineIn != null)
                                {
                                    fields = lineIn.Split(',');
                                    //Writing to file
                                    FileStream wfs2 = new FileStream(tempFile, FileMode.Append, FileAccess.Write);
                                    StreamWriter outputStream2 = new StreamWriter(wfs2);

                                    //if (deleteChoice == "Y")
                                    //{
                                    if (fields[0] != selectedName)
                                    {
                                        outputStream2.WriteLine(lineIn);
                                    }

                                    // }
                                    outputStream2.Close();
                                    wfs2.Close();
                                    lineIn = inputStream3.ReadLine();
                                }



                                inputStream.Close();
                                File.Delete("friends.txt");
                                File.Move(tempFile, "friends.txt");
                                break;
                            }
                            else break;
                        }
                        else
                        {
                            Console.WriteLine("A record for {0} could not be found", selectedName);
                            break;
                        }

                    case "5":
                        Console.WriteLine("Enter a name");
                        selectedName = Console.ReadLine().ToUpper();
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
                        //string tempFile = Path.GetTempFileName();
                        tempFile = Path.GetTempFileName();



                        fs.Position = 0;
                        StreamReader inputStream4 = new StreamReader(fs);
                        lineIn = inputStream4.ReadLine();
                        if (exists)
                        {
                            Console.WriteLine("\nWhich detail for {0} would you like to edit?", selectedName);
                            Console.WriteLine("1. {0}'s name", selectedName);
                            Console.WriteLine("2. {0}'s address line 1", selectedName);
                            Console.WriteLine("3. {0}'s address line 2", selectedName);
                            Console.WriteLine("4. {0}'s address line 3", selectedName);
                            Console.WriteLine("5. {0}'s number", selectedName);
                            string updateChoice = Console.ReadLine().ToUpper();
                            if (updateChoice == "1" || updateChoice == "2" || updateChoice == "3" || updateChoice == "4" || updateChoice == "5")
                            {
                                Console.WriteLine("\nEnter the new value desired");
                                string updateValue = Console.ReadLine().ToUpper();
                                while (lineIn != null)
                                {
                                    fields = lineIn.Split(',');
                                    //Writing to file
                                    FileStream wfs2 = new FileStream(tempFile, FileMode.Append, FileAccess.Write);
                                    StreamWriter outputStream2 = new StreamWriter(wfs2);

                                    if (updateChoice == "1")
                                    {
                                        if (fields[0] != selectedName)
                                        {
                                            outputStream2.WriteLine(lineIn);
                                        }
                                        else if (fields[0] == selectedName)
                                        {
                                            outputStream2.WriteLine("{0},{1},{2},{3},{4}", updateValue, fields[1], fields[2], fields[3], fields[4]);
                                        }
                                    }
                                    else if (updateChoice == "2")
                                    {
                                        if (fields[0] != selectedName)
                                        {
                                            outputStream2.WriteLine(lineIn);
                                        }
                                        else if (fields[0] == selectedName)
                                        {
                                            outputStream2.WriteLine("{0},{1},{2},{3},{4}", fields[0], updateValue, fields[2], fields[3], fields[4]);
                                        }
                                    }
                                    else if (updateChoice == "3")
                                    {
                                        if (fields[0] != selectedName)
                                        {
                                            outputStream2.WriteLine(lineIn);
                                        }
                                        else if (fields[0] == selectedName)
                                        {
                                            outputStream2.WriteLine("{0},{1},{2},{3},{4}", fields[0], fields[1], updateValue, fields[3], fields[4]);
                                        }
                                    }
                                    else if (updateChoice == "4")
                                    {
                                        if (fields[0] != selectedName)
                                        {
                                            outputStream2.WriteLine(lineIn);
                                        }
                                        else if (fields[0] == selectedName)
                                        {
                                            outputStream2.WriteLine("{0},{1},{2},{3},{4}", fields[0], fields[1], fields[2], updateValue, fields[4]);
                                        }
                                    }
                                    else if (updateChoice == "5")
                                    {
                                        if (fields[0] != selectedName)
                                        {
                                            outputStream2.WriteLine(lineIn);
                                        }
                                        else if (fields[0] == selectedName)
                                        {
                                            outputStream2.WriteLine("{0},{1},{2},{3},{4}", fields[0], fields[1], fields[2], fields[3], updateValue);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Selection");
                                        break;
                                    }
                                    outputStream2.Close();
                                    wfs2.Close();
                                    lineIn = inputStream4.ReadLine();
                                }


                                inputStream.Close();
                                File.Delete("friends.txt");
                                File.Move(tempFile, "friends.txt");

                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection");
                                break;
                            }

                        }
                        else {
                            Console.WriteLine("{0} could not be found",selectedName);
                            break;
                        }

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
