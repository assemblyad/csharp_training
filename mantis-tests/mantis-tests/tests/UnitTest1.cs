using NUnit.Framework;
using System;

namespace mantis_tests.tests
{
    [TestFixture]
    public class UnitTest1: TestBase
    {
        //[Test]
        public void JamesTestConnetion()
        {
            AccountData account = new AccountData()
            {
                Name ="xxx2", Password = "yyyy"
            };
            Assert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));
        }
    }
}
