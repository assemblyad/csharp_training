using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupExistenceValidationBaseTest
    {
        [Test]
        public void GroupModification()
        {
            GroupData group = new GroupData("name");
            group.Header = "Newheader";
            group.Footer = "Newfooter";
            app.Groups.Modify(0,group);
        }
    }
}
