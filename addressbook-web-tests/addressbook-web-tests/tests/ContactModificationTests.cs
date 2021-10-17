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
            ContactData newData = new ContactData("BB", "CC");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

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
                    Assert.AreNotEqual(oldData.LastName, contact.LastName);
                    Assert.AreNotEqual(oldData.FirstName,contact.FirstName);
                }
            }
        }
    }
}
