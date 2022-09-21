using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Address_Book
{
    class IOOperation
    {
        const string filepath = @"D:\LFP-183\Practice\AddressBook\Address_Book\AddressBook.csv";
        public static List<string> list;

        //file writes the addressbook in a file
        public static void GetDictionary(Dictionary<string, List<NewMember>> addressbooknames)
        {
            File.WriteAllText(filepath, string.Empty);
            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                list = new List<string>();
                list.Add("The address book name is: " + kvp.Key);
                foreach (var member in kvp.Value)
                {
                    list.Add(member.ToString());
                }
                try
                {
                    File.AppendAllLines(filepath, list);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            try
            {
                string[] text = File.ReadAllLines(filepath);
                Console.WriteLine("The Content written in the file");
                foreach (var mem in text)
                    Console.WriteLine(mem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void ReadAddressBook()
        {
            string[] text = File.ReadAllLines(filepath);
            foreach (var mem in text)
                Console.WriteLine(mem);
        }
        //writes to csv
        public static void CSVOperations(Dictionary<string, List<NewMember>> addressbooknames)
        {
            string export = @"D:\LFP-183\Practice\AddressBook\Address_Book\AddressBook.json";

            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                //normal config
                var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
                foreach (var mem in kvp.Value)
                {
                    List<NewMember> list = new List<NewMember>();
                    list.Add(mem);
                    //Opening file open with append mode
                    using (var stream = File.Open(export, FileMode.Append))
                    using (var writer = new StreamWriter(stream))
                    using (var csvWriter = new CsvWriter(writer, config))
                    {
                        //writes the data next row
                        csvWriter.WriteRecords(list);
                    }
                    //header config for not printing
                    config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false,
                    };

                }



            }
            //Reads from CSV
            using (var reader = new StreamReader(export))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<NewMember>().ToList();
                foreach (NewMember member in records)
                {
                    if (member.FirstName == "firstname")
                    {
                        Console.WriteLine(" ");
                        continue;
                    }
                    Console.WriteLine(member.ToString());
                }

            }



        }
    }
}