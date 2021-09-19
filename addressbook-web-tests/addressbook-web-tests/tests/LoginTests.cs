using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    class LoginTests: TestBase
    {
        [Test]
        public void LoginWithValidCredential()
        {
            //prepare
            app.Auth.LogOut();

            //acction
            AcccountData account = new AcccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }
        [Test]
        public void LoginWithInValidCredential()
        {
            //prepare
            app.Auth.LogOut();

            //acction
            AcccountData account = new AcccountData("admin", "123456");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
