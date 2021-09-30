using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupExistenceValidationBaseTest
    {
        [Test]
        public void GroupModification()
        {
            GroupData newData = new GroupData("name");
            newData.Header = "Newheader";
            newData.Footer = "Newfooter";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
