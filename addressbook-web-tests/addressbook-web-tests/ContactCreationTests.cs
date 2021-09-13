using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreation : TestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            GoToHomePage();
            Login(new AcccountData("admin", "secret"));
            InitCreateContact();
            FillContactForm(new Contact("F","L"));
            SubmitContactCreation();
            GoToContactHomePage();
        }
    }
}
