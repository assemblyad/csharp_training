using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests: AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.Modify();
        }
    }
}
