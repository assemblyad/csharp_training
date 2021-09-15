using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModification()
        {
            GroupData group = new GroupData("name");
            group.Header = "Newheader";
            group.Footer = "Newfooter";
            app.Groups.Modify(group,18);
        }
    }
}
