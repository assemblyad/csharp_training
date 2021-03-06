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

            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            //app.Groups.Modify(0, newData);
            app.Groups.Modify(oldData.ID,newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if (group.ID == oldData.ID)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
