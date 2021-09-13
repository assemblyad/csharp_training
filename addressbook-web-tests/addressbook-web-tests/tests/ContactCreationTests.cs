using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreation : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts.Creation();
        }
    }
}
