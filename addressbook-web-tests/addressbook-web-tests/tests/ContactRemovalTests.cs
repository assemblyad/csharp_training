using NUnit.Framework;
using System;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactRemovalTests: AuthTestBase
    {
        [Test]
        public void ContactRemoval()
        {
            app.Contacts.Removal(23);
        }
    }
}
