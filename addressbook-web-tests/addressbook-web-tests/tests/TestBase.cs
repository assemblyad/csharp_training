using NUnit.Framework;

namespace WebAdressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AcccountData("admin", "secret"));

        }

        [TearDown]
        public void TeardownTest()
        {
            app.stop();
        }

    }
}
