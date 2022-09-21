﻿using System;
using System.Collections.Generic;

namespace Address_Book
{ 
    class Program
    {
        //Declared Dictionary
        public static Dictionary<string, List<NewMember>> addressbooknames = new Dictionary<string, List<NewMember>>();
        public static Dictionary<string, List<NewMember>> cities = new Dictionary<string, List<NewMember>>();
        public static Dictionary<string, List<NewMember>> states = new Dictionary<string, List<NewMember>>();
        public static List<NewMember> cityname;
        public static List<NewMember> statename;
        public Program()
        {
            cityname = new List<NewMember>();
            statename = new List<NewMember>();
        }
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
            Console.WriteLine("Enter 1 to search the contacts based on city name and state");
            Console.WriteLine("Enter 2 to print contact list based on city name and states");
            Console.WriteLine("Enter 3 to print contact list based on sorting contacts");
            string options = Console.ReadLine();
            if (options == "1")
            {
                Console.WriteLine("Enter City name");
                string cityname = Console.ReadLine();
                Console.WriteLine("Enter state name");
                string state = Console.ReadLine();
                //using keyvalue to get value of the key.
                foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
                {
                    Console.WriteLine("The address Books is:{0}", kvp.Key);
                    Console.WriteLine("The Contact List from {0} or {1}", cityname, state);
                    AddressBook.Search(kvp.Value, cityname, state);
                }
            }
            else if (options == "2")
            {
                //print the data based on city name using group by and lambda function
                AddressBook address = new AddressBook();
                foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
                {
                    var result = kvp.Value.GroupBy(mem => mem.City.ToLower());
                    if (result != null)
                    {
                        foreach (var val in result)
                        {
                            foreach (NewMember member in val)
                            {
                                if (cities.ContainsKey(member.City.ToLower()))
                                {
                                    foreach (KeyValuePair<string, List<NewMember>> key in cities)
                                    {
                                        if (key.Key.ToLower() == member.City.ToLower())
                                        {
                                            key.Value.Add(member);
                                        }
                                    }
                                }
                                else
                                {
                                    Program program = new Program();
                                    cityname.Add(member);
                                    cities.Add(member.City.ToLower(), cityname);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Contacts");
                    }
                }
                //uses lambda function to group by state and add it to the dictionary
                foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
                {
                    var result = kvp.Value.GroupBy(mem => mem.State.ToLower());
                    if (result != null)
                    {
                        foreach (var val in result)
                        {
                            foreach (NewMember member in val)
                            {
                                if (states.ContainsKey(member.State.ToLower()))
                                {
                                    foreach (KeyValuePair<string, List<NewMember>> key in states)
                                    {
                                        if (key.Key.ToLower() == member.State.ToLower())
                                        {
                                            key.Value.Add(member);
                                        }
                                    }
                                }
                                else
                                {
                                    Program program = new Program();
                                    statename.Add(member);
                                    states.Add(member.State.ToLower(), statename);
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Contacts");
                    }
                }
                PrintDictionaries(cities, "City");
                Console.WriteLine("   ");
                PrintDictionaries(states, "States");
                DisplayCount();
            }
            else if (options == "3")
            {
                AddressBook addressBook = new AddressBook();
                Console.WriteLine("Enter 1 to sort based on firstname");
                Console.WriteLine("Enter 2 to sort based on cityname");
                Console.WriteLine("Enter 3 to sort based on statename");
                Console.WriteLine("Enter 4 to sort based on PinCode");
                string option = Console.ReadLine();
                if (option == "1")
                {
                    addressBook.SortBasedOnNames(addressbooknames);
                }
                else if (option == "2")
                {
                    addressBook.SortBasedOnCityName(addressbooknames);
                }
                else if (option == "3")
                {
                    addressBook.SortBasedOnStateName(addressbooknames);
                }
                else if (option == "4")
                {
                    addressBook.SortBasedOnPinCode(addressbooknames);
                }
            }
        }
        //print state and country dictionaries
        public static void PrintDictionaries(Dictionary<string, List<NewMember>> temp, string group)
        {
            AddressBook addressbook = new AddressBook();
            Console.WriteLine("**** Printing the entire contact in the address book grouped by {0}", group);
            foreach (KeyValuePair<string, List<NewMember>> kvp in temp)
            {
                Console.WriteLine(" ");
                Console.WriteLine("The Contacts in the {0} {1}", group, char.ToUpper(kvp.Key[0]) + kvp.Key.Substring(1));
                foreach (var member in kvp.Value)
                {
                    addressbook.PrintPerson(member);
                }
            }
        }
        public static void DisplayCount()
        {
            Console.WriteLine("The counts based on states and cities");
            Console.WriteLine("Group by city");
            foreach (KeyValuePair<string, List<NewMember>> kvp in cities)
            {
                Console.WriteLine("The city {0} have {1} contacts", kvp.Key, kvp.Value.Count);
            }
            Console.WriteLine("Group by state");
            foreach (KeyValuePair<string, List<NewMember>> kvp in states)
            {
                Console.WriteLine("The state {0} have {1} contacts", kvp.Key, kvp.Value.Count);
            }
        }
    }
}