using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests: ContactExistenceValidationBaseTest
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("AA", "BB");

            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(oldData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName =  newData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                if (contact.ID == oldData.ID)
                {
                    Assert.AreEqual(oldData.LastName, contact.LastName);
                    Assert.AreEqual(oldData.FirstName,contact.FirstName);
                }
            }
        }
    }
}
