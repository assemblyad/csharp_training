using NUnit.Framework;
using System;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: TestBase
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contacts.Removal(23);
        }
    }
}
