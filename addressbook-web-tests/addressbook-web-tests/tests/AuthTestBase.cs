using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAdressbookTests
{
    public class AuthTestBase: TestBase
    {

        [SetUp]
        public void SetupTestLogin()
        {
            app.Auth.Login(new AcccountData("admin", "secret"));
        }

    }
}
