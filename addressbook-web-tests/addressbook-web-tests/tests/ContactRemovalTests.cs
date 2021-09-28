using NUnit.Framework;
using System;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: ContactExistenceValidationBaseTest
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contacts.Removal();
        }
    }
}
