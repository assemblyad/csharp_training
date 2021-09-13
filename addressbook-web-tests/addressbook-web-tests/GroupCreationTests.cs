using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests: TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AcccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("name");
            group.Header="header";
            group.Footer = "footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}
