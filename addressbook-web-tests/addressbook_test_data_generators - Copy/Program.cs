using System;
using System.IO;
using WebAdressbookTests;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];


            if (dataType == "group") {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(5))
                    {
                        Header = TestBase.GenerateRandomString(6),
                        Footer = TestBase.GenerateRandomString(6)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            } else if (dataType == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(5), TestBase.GenerateRandomString(5))
                    {
                        NickName = TestBase.GenerateRandomString(6)
                    });
                }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }

            }else
            {
                    System.Console.Out.Write("Unrecognized data type provided " + dataType);
            }

            writer.Close();
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contatcs in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contatcs.FirstName,
                    contatcs.LastName,
                    contatcs.NickName));
            }
        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

    }

}
