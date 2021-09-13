using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AcccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroupPage(1);
            app.Groups.RemoveGroupPage();
            app.Groups.ReturnToGroupsPage();
        }
    }
}
