using NUnit.Framework;

namespace WebAdressbookTests
{
    public class TestBase
    {

        protected ApplicationManager app;
        [SetUp]
        public void SetUpApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    }
}
