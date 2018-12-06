using System;
using System.Collections.Generic;
using System.IO;

namespace GreeterApp
{
    class ProcessFile
    {
        public ProcessFile()
        {

        }
        public void WriteToFile(string Data, string FileName)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Append, FileAccess.Write);
                //CryptoStream cStream = new CryptoStream(fStream, new AesManaged().CreateEncryptor(Key, IV), CryptoStreamMode.Write);
                StreamWriter sWriter = new StreamWriter(fs);


                sWriter.WriteLine(Data);
                sWriter.Close();
                fs.Close();

            }
            catch
            {
                Console.WriteLine("error");
            }

        }
        public string ReadFromFile(string FileName)
        {
            try
            {

                FileStream fs = File.Open(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sReader = new StreamReader(fs);
                string val = sReader.ReadToEnd();
                sReader.Close();
                fs.Close();
                return val;
            }

            catch
            {
                Console.WriteLine("error");
                return "error";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ProcessFile processFile = new ProcessFile();
            ContactsMemory contactsMemory = new ContactsMemory();
            //Greeter is a terminal application that stores friends contact information
            string lineIn;  // variable where data from file is stored
            string[] fields = new string[5];
            //Display a title bar.
            Console.WriteLine("\t**********************************************");
            Console.WriteLine("\t***  Welcome to Your Friend Library.  ***");
            Console.WriteLine("\t**********************************************");
            Boolean exit = false;
            do
            {
                string Final = processFile.ReadFromFile("friends.txt");
                lineIn = Final;

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
                        contactsMemory.GetContact();
                        break;
                    case "2":
                        contactsMemory.GetContacts();
                        break;
                    case "3":
                        contactsMemory.CreateContact();
                        break;
                    case "4":
                        contactsMemory.DeleteContact();
                        break;
                    case "5":
                        contactsMemory.UpdateContact();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Unknown selection");
                        break;
                }
            } while (!exit);
        }

    }

    class Contact
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PhoneNumber { get; set; }

        public Contact()
        {

        }
        public Contact(string name, string addressLine1, string addressLine2, string addressLine3, string phoneNum)
        {
            Name = name;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            PhoneNumber = phoneNum;
        }
        public override string ToString()
        {
            return Name + "," + AddressLine1 + "," + AddressLine2 + "," + AddressLine3 + "," + PhoneNumber;
        }

    }

    class ContactsMemory
    {
        public List<Contact> ContactList { get; set; }


        public void GetContacts()
        {
            ProcessFile processFile = new ProcessFile();
            string Final = processFile.ReadFromFile("friends.txt");
            string[] result = Final.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", "Name", "Address Line 1", "Address Line 2", "Address Line 3", "Phone Number");
            for (int i = 0; i < result.Length; i++)
            {
                string[] values = result[i].Split(',');
                Contact contact = new Contact();
                contact.Name = values[0];
                contact.AddressLine1 = values[1];
                contact.AddressLine2 = values[2];
                contact.AddressLine3 = values[3];
                contact.PhoneNumber = values[4];
                Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", contact.Name, contact.AddressLine1, contact.AddressLine2, contact.AddressLine3, contact.PhoneNumber);
            }
        }
        public void CreateContact()
        {
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
            Contact newContact = new Contact(newName, AddressLine1, AddressLine2, AddressLine3, newNumber);
            ProcessFile processFile = new ProcessFile();
            processFile.WriteToFile(newContact.ToString(), "friends.txt");
        }
        public void GetContact()
        {
            Console.WriteLine("Enter a name");
            string selectedName = Console.ReadLine().ToUpper();
            Boolean exists = false;
            ProcessFile processFile = new ProcessFile();
            string Final = processFile.ReadFromFile("friends.txt");
            string[] result = Final.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                string[] values = result[i].Split(',');
                if (values[0] == selectedName)
                {
                    exists = true;
                    if (exists)
                    {
                        Console.WriteLine("\nWe have a record for {0}", values[0]);
                        Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", "Name", "Address Line 1", "Address Line 2", "Address Line 3", "Phone Number");
                        Console.WriteLine("{0,-20}\t{1,-15}\t{2,-15}\t{3,-15}\t{4,-10}", values[0], values[1], values[2], values[3], values[4]);
                    }
                }
            }
            if (!exists)
                Console.WriteLine("\nThere is no record for {0}", selectedName);

        }
        public void DeleteContact()
        {
            Console.WriteLine("Enter a name");
            string selectedName = Console.ReadLine().ToUpper();
            Boolean exists = false;
            ProcessFile processFile = new ProcessFile();
            string Final = processFile.ReadFromFile("friends.txt");
            string[] result = Final.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                string[] values = result[i].Split(',');
                if (values[0] == selectedName)
                {
                    exists = true;
                }
            }
            string tempFile = Path.GetTempFileName();
            if (exists)
            {
                Console.WriteLine("\nWould you like to delete {0}'s details? (Y/N)", selectedName);
                string deleteChoice = Console.ReadLine().ToUpper();
                if (deleteChoice == "Y")
                {
                    for (int i = 0; i < result.Length; i++)
                    {
                        string[] values = result[i].Split(',');
                        if (values[0] != selectedName)
                        {
                            processFile.WriteToFile(result[i], tempFile);
                        }
                    }
                    File.Delete("friends.txt");
                    File.Move(tempFile, "friends.txt");
                }
            }
            else
            {
                Console.WriteLine("A record for {0} could not be found", selectedName);
            }
        }
        public void UpdateContact()
        {
            Console.WriteLine("Enter a name");
            String selectedName = Console.ReadLine().ToUpper();
            Boolean exists = false;
            ProcessFile processFile = new ProcessFile();
            string Final = processFile.ReadFromFile("friends.txt");
            string[] result = Final.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < result.Length; i++)
            {
                string[] values = result[i].Split(',');
                if (values[0] == selectedName)
                {
                    exists = true;
                }
            }
            string tempFile = Path.GetTempFileName();
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
                    for (int i = 0; i < result.Length; i++)
                    {
                        string[] values = result[i].Split(',');
                        if (updateChoice == "1")
                        {
                            if (values[0] != selectedName)
                            {
                                processFile.WriteToFile(result[i], tempFile);
                            }
                            else if (values[0] == selectedName)
                            {
                                processFile.WriteToFile(String.Format("{0},{1},{2},{3},{4}", updateValue, values[1], values[2], values[3], values[4]), tempFile);
                            }
                        }
                        else if (updateChoice == "2")
                        {
                            if (values[0] != selectedName)
                            {
                                processFile.WriteToFile(result[i], tempFile);
                            }
                            else if (values[0] == selectedName)
                            {
                                processFile.WriteToFile(String.Format("{0},{1},{2},{3},{4}", values[0], updateValue, values[2], values[3], values[4]), tempFile);
                            }
                        }
                        else if (updateChoice == "3")
                        {
                            if (values[0] != selectedName)
                            {
                                processFile.WriteToFile(result[i], tempFile);
                            }
                            else if (values[0] == selectedName)
                            {
                                processFile.WriteToFile(String.Format("{0},{1},{2},{3},{4}", values[0], values[1], updateValue, values[3], values[4]), tempFile);
                            }
                        }
                        else if (updateChoice == "4")
                        {
                            if (values[0] != selectedName)
                            {
                                processFile.WriteToFile(result[i], tempFile);
                            }
                            else if (values[0] == selectedName)
                            {
                                processFile.WriteToFile(String.Format("{0},{1},{2},{3},{4}", values[0], values[1], values[2], updateValue, values[4]), tempFile);
                            }
                        }
                        else if (updateChoice == "5")
                        {
                            if (values[0] != selectedName)
                            {
                                processFile.WriteToFile(result[i], tempFile);
                            }
                            else if (values[0] == selectedName)
                            {
                                processFile.WriteToFile(String.Format("{0},{1},{2},{3},{4}", values[0], values[1], values[2], values[3], updateValue), tempFile);
                            }
                        }


                        else
                        {
                            Console.WriteLine("Invalid Selection");
                            break;
                        }

                    }


                    //            //inputStream.Close();
                    File.Delete("friends.txt");
                    File.Move(tempFile, "friends.txt");

                    //            break;
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Invalid selection");
                    //            break;
                    //        }

                    //    }

                }

                else
                {
                    Console.WriteLine("Invalid selection");
                }

            }
            else
            {
                Console.WriteLine("{0} could not be found", selectedName);
            }

        }
    }
}
