using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests: ContactExistenceValidationBaseTest
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.Modify(0);
        }
    }
}
