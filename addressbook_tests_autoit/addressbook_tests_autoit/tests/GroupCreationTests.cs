using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupsList();

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);

            List<GroupData> newGroups = app.Groups.GetGroupsList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
            

        }
    }
}
