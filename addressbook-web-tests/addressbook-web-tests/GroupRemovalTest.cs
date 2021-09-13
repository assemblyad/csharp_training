using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GoToHomePage();
            Login(new AcccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroupPage(1);
            RemoveGroupPage();
            ReturnToGroupsPage();
        }
    }
}
