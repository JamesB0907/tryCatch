using System;
using System.Collections.Generic;

class Contact
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}

class AddressBook
{
    private List<Contact> contacts;
    public AddressBook()
    {
        contacts = new List<Contact>();
    }
    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public Contact? GetByEmail(string email)
    {
        return contacts.Find(c => c.Email == email);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a few contacts
            Contact bob = new Contact()
            {
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@email.com",
                Address = "100 Some Ln, Testville, TN 11111"
            };
            Contact sue = new Contact()
            {
                FirstName = "Sue",
                LastName = "Jones",
                Email = "sue.jones@email.com",
                Address = "322 Hard Way, Testville, TN 11111"
            };
            Contact juan = new Contact()
            {
                FirstName = "Juan",
                LastName = "Lopez",
                Email = "juan.lopez@email.com",
                Address = "888 Easy St, Testville, TN 11111"
            };

            // Create an AddressBook and add some contacts to it
            AddressBook addressBook = new AddressBook();
            addressBook.AddContact(bob);
            addressBook.AddContact(sue);
            addressBook.AddContact(juan);

            // Try to add a contact a second time
            addressBook.AddContact(sue);


            // Create a list of emails that match our Contacts
            List<string> emails = new List<string>() {
                sue.Email,
                juan.Email,
                bob.Email,
            };

            // Insert an email that does NOT match a Contact
            emails.Insert(1, "not.in.addressbook@email.com");


            // Search the AddressBook by email and print the information about each Contact
            foreach (string email in emails)
            {
                try
                {
                    Contact? contact = addressBook.GetByEmail(email);
                    if (contact != null)
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"Name: {contact.FullName}");
                        Console.WriteLine($"Email: {contact.Email}");
                        Console.WriteLine($"Address: {contact.Address}");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------");
                        Console.WriteLine($"Contact not found for email: {email}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Error retrieving contact for email: {email}");
                    Console.WriteLine($"Error message: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
