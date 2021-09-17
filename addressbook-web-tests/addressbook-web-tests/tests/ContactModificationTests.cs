using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactModificationTests:TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.Modify(26);
        }
    }
}
