using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreation : TestBase
    {
        [Test]
        public void TheContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AcccountData("admin", "secret"));
            app.Contacts.InitCreateContact();
            app.Contacts.FillContactForm(new Contact("F","L"));
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoToContactHomePage();
        }
    }
}
