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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Removal(0);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
