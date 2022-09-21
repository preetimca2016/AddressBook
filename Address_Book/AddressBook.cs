using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book
{
    class AddressBook
    {
        //create list to add contacts
        public static List<NewMember> contactList = new List<NewMember>();
        public static void AddaPerson()
        {
            NewMember newMember = new NewMember();
            Console.Write("Enter First Name: ");
            newMember.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            newMember.LastName = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            newMember.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Address: ");
            newMember.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            newMember.City = Console.ReadLine();
            Console.Write("Enter State: ");
            newMember.State = Console.ReadLine();
            Console.Write("Enter Pincode: ");
            newMember.PinCode = Console.ReadLine();
            contactList.Add(newMember);
        }
        public static void PrintPerson(NewMember member)
        {
            Console.WriteLine("First Name: " + member.FirstName);
            Console.WriteLine("Last Name: " + member.LastName);
            Console.WriteLine("Phone Number: " + member.PhoneNumber);
            Console.WriteLine("Address" + member.Address);
            Console.WriteLine("City: " + member.City);
            Console.WriteLine("State: " + member.State);
            Console.WriteLine("Pincode: " + member.PinCode);
            Console.WriteLine("");
        }
        public static void ListContactPeople()
        {
            if (contactList.Count > 0)
            {
                Console.WriteLine("The Contact List : ");
                foreach (var member in contactList)
                {
                    PrintPerson(member);
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty.");
                return;
            }
        }
    }
}
 
