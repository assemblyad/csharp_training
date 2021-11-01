using NUnit.Framework;
using System;
using System.Text;

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
