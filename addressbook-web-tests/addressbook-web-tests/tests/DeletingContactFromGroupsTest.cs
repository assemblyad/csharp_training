using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    class DeletingContactFromGroupsTest : AuthTestBase
    {
        [Test]
        public void TestDeletingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();

            //actions 
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            //oldList.Add(contact);
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
