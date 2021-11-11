using NUnit.Framework;
using System;
using System.Text;

namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {

        [SetUp]
        public void SetupTestLogin()
        {
            app.Auth.Login(new AccountData("administrator", "root"));
        }

    }
}
