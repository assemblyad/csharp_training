using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: GroupExistenceValidationBaseTest
    {
        [Test]
        public void GroupRemovalTest()
        {
            //List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            //app.Groups.Remove(0);
            app.Groups.Remove(toBeRemoved); 
            Assert.AreEqual(oldGroups.Count-1, app.Groups.GetGroupCount());
            //List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData element in newGroups)
            {
                Assert.AreNotEqual(element.ID, toBeRemoved.ID);
            }
        }
    }
}
