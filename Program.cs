namespace Phonebook_Application
{
    public class Program
    {
        // Checks if a string contains only numeric digits

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Phonebook phonebook = new Phonebook();

            while (true)
            {
                Console.Clear();  // Clears the console for a fresh menu display
                Console.WriteLine("===================================");
                Console.WriteLine("         📞 Phonebook Menu          ");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contacts");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.WriteLine("-----------------------------------");
                Console.Write("Please enter your choice (1-5): ");
            

            string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        string name;
                        while (true)
                        {
                            Console.Write("Enter name: ");
                            name = Console.ReadLine()!;
                            if (string.IsNullOrWhiteSpace(name))
                            {
                                Console.WriteLine("Name cannot be empty. Please try again.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        string number;
                        while (true)
                        {
                            Console.Write("Enter phone number (digits only): ");
                            number = Console.ReadLine()!;
                            if (string.IsNullOrWhiteSpace(number))
                            {
                                Console.WriteLine("Phone number cannot be empty. Please try again.");
                            }
                            else if (!IsDigitsOnly(number))
                            {
                                Console.WriteLine("Phone number must contain digits only. Please try again.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        phonebook.AddContact(name, number);
                        Console.WriteLine("Contact added.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "2":
                        phonebook.ViewContacts();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Enter name to search: ");
                        string searchName = Console.ReadLine();
                        var contact = phonebook.SearchContact(searchName);
                        if (contact != null)
                            Console.WriteLine($"Found: {contact}");
                        else
                            Console.WriteLine("Contact not found.");

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "4":
                        Console.Write("Enter name to delete: ");
                        string deleteName = Console.ReadLine();
                        phonebook.DeleteContact(deleteName);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        return;

                default:
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
                    break;
                }
            }
        }
    }
}
