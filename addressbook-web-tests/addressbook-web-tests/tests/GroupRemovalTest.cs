using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: GroupExistenceValidationBaseTest
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Groups.Remove();
        }
    }
}
