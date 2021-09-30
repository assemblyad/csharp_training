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
            ContactData newData = new ContactData("FD", "LD");

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0);
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname =  newData.Lastname;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
