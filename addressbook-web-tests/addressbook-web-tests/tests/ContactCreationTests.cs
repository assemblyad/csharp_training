using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreation : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            // preparation
            app.Contacts.Creation();
        }
    }
}
