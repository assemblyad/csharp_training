using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: ContactExistenceValidationBaseTest
    {
        [Test]
        public void ContactRemoval()
        {
            //List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData contactToBeRemoved = oldContacts[0];

            //app.Contacts.Removal(0);
            app.Contacts.Removal(contactToBeRemoved);

            Assert.AreEqual(oldContacts.Count-1, app.Contacts.GetContactCount());
            //List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.ID, contactToBeRemoved.ID);
            }
        }
    }
}
