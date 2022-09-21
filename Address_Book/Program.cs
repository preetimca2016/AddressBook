using System;
using System.Collections.Generic;

namespace Address_Book
{
    class Program
    {
        //Declared Dictionary
        public static Dictionary<string, List<NewMember>> addressbooknames = new Dictionary<string, List<NewMember>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book System!");
            Console.WriteLine("Enter the number of address books to be added to the system: ");
            int addressbooks = Convert.ToInt32(Console.ReadLine());
            int noofbooksadded = 0;
            while (noofbooksadded < addressbooks)
            {
                Console.WriteLine("Enter the address book name: ");
                string addressbookname = Console.ReadLine();
                ///obj creation
                AddressBook addressBook = new AddressBook();
                Console.WriteLine("Enter the no of contacts in the address book: ");
                int noofcontatcs = Convert.ToInt32(Console.ReadLine());

                while (noofcontatcs != 0)
                {
                    Console.WriteLine("Enter the details of contact to be added: ");
                    bool found = addressBook.AddaPerson();
                    if (!found)
                    {
                        noofcontatcs--;
                        Console.WriteLine(" ");
                        addressBook.ListContactPeople();
                    }
                }
                Console.WriteLine("To Modify Details Press 1/ To delete a contact detail Press 2/Else Press 0");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 1)
                {
                    addressBook.Modify();
                    Console.WriteLine(" ");
                    addressBook.ListContactPeople();
                }
                else if (option == 2)
                {
                    addressBook.DeleteDetails();
                    Console.WriteLine(" ");
                    addressBook.ListContactPeople();
                }
                if (addressbooknames.ContainsKey(addressbookname))
                {
                    Console.WriteLine("Existing address book name : {0} . Please retry!", addressbookname);
                    return;
                }
                else
                {
                    ///adding details to the dictionary
                    addressbooknames.Add(addressbookname, addressBook.contactList);
                }
                noofbooksadded++;
            }
            //using keyvalue to get value of the key.
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                Console.WriteLine("The address Books are:{0}", kvp.Key);
            }
        }
    }
    //class Program
    //{
    //    //Declared Dictionary
    //    public static Dictionary<string, List<NewMember>> addressbooknames = new Dictionary<string, List<NewMember>>();
    //    static void Main(string[] args)
    //    {

    //        Console.WriteLine("Welcome to Address Book System!");
    //        Console.WriteLine("Enter the number of address books to be added to the system: ");
    //        int addressbooks = Convert.ToInt32(Console.ReadLine());
    //        int noofbooksadded = 0;
    //        while (noofbooksadded < addressbooks)
    //        {
    //            Console.WriteLine("Enter the address book name: ");
    //            string addressbookname = Console.ReadLine();
    //            ///obj creation
    //            AddressBook addressBook = new AddressBook();
    //            Console.WriteLine("Enter the no of contacts in the address book: ");
    //            int noofcontatcs = Convert.ToInt32(Console.ReadLine());

    //            while (noofcontatcs != 0)
    //            {
    //                Console.WriteLine("Enter the details of contact to be added: ");
    //                addressBook.AddaPerson();
    //                noofcontatcs--;
    //                Console.WriteLine(" ");
    //                //addressBook.ListContactPeople();
    //            }
    //            Console.WriteLine("To Modify Details Press 1/ To delete a contact detail Press 2/Else Press 0");
    //            int option = Convert.ToInt32(Console.ReadLine());
    //            if (option == 1)
    //            {
    //                addressBook.Modify();
    //                Console.WriteLine(" ");
    //               // addressBook.ListContactPeople();
    //            }
    //            else if (option == 2)
    //            {
    //                //addressBook.DeleteDetails();
    //                Console.WriteLine(" ");
    //                //addressBook.ListContactPeople();
    //            }
    //            if (addressbooknames.ContainsKey(addressbookname))
    //            {
    //                Console.WriteLine("Existing address book name : {0} . Please retry!", addressbookname);
    //                return;
    //            }
    //            else
    //            {
    //                ///adding details to the dictionary
    //                addressbooknames.Add(addressbookname, addressBook.contactList);
    //            }
    //            noofbooksadded++;
    //        }
    //        //using keyvalue to get value of the key.
    //        foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
    //        {
    //            Console.WriteLine("The address Books are:{0}", kvp.Key);
    //        }
    //    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        Console.WriteLine("Welcome to Address Book System!");
    //        while (true)
    //        {
    //            Console.WriteLine("Enter an Option:");
    //            Console.WriteLine("Enter 1 to Add a Member in a contact list");
    //            Console.WriteLine("Enter 2 to Print the Member in contact list");
    //            Console.WriteLine("Enter 3 to Modify the contact details");
    //            Console.WriteLine("Enter 4 to Delete the contact details");
    //            Console.WriteLine("Enter 5 to Exit");
    //            int option = Convert.ToInt32(Console.ReadLine());
    //            switch (option)
    //            {
    //                case 1:
    //                    AddressBook.AddaPerson();
    //                    break;
    //                case 2:
    //                    AddressBook.ListContactPeople();
    //                    break;
    //                case 3:
    //                    AddressBook.Modify();
    //                    break;
    //                case 4:
    //                    AddressBook.DeleteDetails();
    //                    break;
    //                case 5:
    //                    return;

    //            }
    //        }

    //    }
    //}
}