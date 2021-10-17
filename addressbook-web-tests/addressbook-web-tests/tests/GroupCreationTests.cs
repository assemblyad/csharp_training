using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests: AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i= 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15)) {
                    Header = GenerateRandomString(50),
                    Footer= GenerateRandomString(50)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string [] lines =File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string [] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXml()
        {
            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));
        }


        [Test,TestCaseSource("GroupDataFromXml")]
        public void GroupCreationTest(GroupData group)
        {
            /*
            GroupData group = new GroupData("MnameN");
            group.Header="MheaderN";
            group.Footer = "MfooterN";
            */

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
           
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

        }
        
        /*
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
        */
        
        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";


            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count+1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
