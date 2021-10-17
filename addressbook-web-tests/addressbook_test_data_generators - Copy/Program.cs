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
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];
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

        }
        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {

        }

    }

}
