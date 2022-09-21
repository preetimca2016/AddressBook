using Address_Book;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AddressBookSystem
{
    class IOOperation
    {
        const string filepath = @"E:\Bridgelabz\Address_Book_System\Address_Book_System\AddressBook.txt";
        public static List<string> list;
        private static object records;

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
            string export = @"D:\LFP-183\Practice\AddressBook\Address_Book\AddressBook.csv";

            foreach (KeyValuePair<string, List<NewMember>> kvp in addressbooknames)
            {
                //normal config
                var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
                foreach (var mem in kvp.Value)
                {
                    List<NewMember> list1 = new List<NewMember>();
                    list1.Add(mem);
                    //Opening file open with append mode
                    using (var stream = File.Open(export, FileMode.Append))
                    using (var writer = new StreamWriter(stream))
                    using (var csvWriter = new CsvWriter(writer, config))
                    {
                        //writes the data next row
                        csvWriter.WriteRecords(list1);
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
            //Json serialze to add object to json file
            string jsonFilepath = @"E:\Bridgelabz\Address_Book_System\Address_Book_System\AddressBookD:\LFP-183\Practice\AddressBook\Address_Book\AddressBook.json";
            JsonSerializer serializer = new JsonSerializer();
            List<NewMember> list = new List<NewMember>();
            using (StreamWriter sw = new StreamWriter(jsonFilepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //serializer to serialize to json
                serializer.Serialize(writer, records);
            }
            Console.WriteLine("Written to JSON");
            //Reading from json file
            List<NewMember> json = JsonConvert.DeserializeObject<List<NewMember>>(File.ReadAllText(jsonFilepath));
            foreach (var member in json)
            {
                //To remove header in Json file
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
