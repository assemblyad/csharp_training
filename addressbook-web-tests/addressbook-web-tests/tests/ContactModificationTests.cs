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
            ContactData newData = new ContactData("FO", "LO");

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(0);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname =  newData.Lastname;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                if (contact.ID == oldData.ID)
                {
                    Assert.AreNotEqual(oldData.Lastname, contact.Lastname);
                    Assert.AreNotEqual(oldData.Firstname,contact.Firstname);
                }
            }
        }
    }
}
