using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    class DeletingContactFromGroupsTest : ContactExistenceValidationBaseTest
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {
            
            GroupData group = GroupData.GetAll()[0];

            List<ContactData> allContacts = ContactData.GetAll();
            ContactData contact = allContacts[0];
            List<GroupData> allGroups = GroupData.GetAll();

            for (int i= 0; i < allGroups.Count; i++)
            {
                //finding first not empty group
                if (allGroups[i].GetContacts().Count()>0)
                {
                    group = allGroups[i];
                    allContacts = group.GetContacts();
                    contact = allContacts[0];
                    break;
                }
                else if (allGroups.Count==(i+1))
                {
                    group = allGroups[i];
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }

            //actions 
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            //oldList.Add(contact);
            allContacts.Remove(contact);
            newList.Sort();
            allContacts.Sort();

            Assert.AreEqual(allContacts, newList);
        }
    }
}
